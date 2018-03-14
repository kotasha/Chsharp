using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;


namespace EFDBContext
{
    public class UpdateDemo
    {
        public UpdateDemo() { }

        public static void UpdateEntity()
        {
            Student stud ;
            // Get student from DB
            using (var ctx = new SchoolDBEntities())
            {
                stud = ctx.Students.Where(s => s.StudentID == 1).FirstOrDefault<Student>();
            }
            // change student name in disconnected mode (out of DBContext scope)
            if (stud != null)
            {
                stud.StudentName = "Updated Student1";
            }

            //save modified entity using new DBContext
            using (var dbCtx = new SchoolDBEntities())
            {
                //Mark entity as modified
                if (stud != null)
                {
                    dbCtx.Entry(stud).State = System.Data.EntityState.Modified;
                    dbCtx.SaveChanges();
                }
            }

            Console.WriteLine("UpdateEntity successfull");

        }

        public static void UpdateOneToOneEntity()
        {
            Student stud;
            // Get student from DB
            using (var ctx = new SchoolDBEntities())
            {
                stud = ctx.Students.Include(s => s.StudentAddress).Where(s => s.StudentID == 1).FirstOrDefault<Student>();
            }
            
            // change student name in disconnected mode (out of context scope)
            if (stud != null)
            {
                stud.StudentName = "updated student";

                if (stud.StudentAddress == null)
                {
                    stud.StudentAddress = new StudentAddress();
                    stud.StudentAddress.StudentID = stud.StudentID;
                    stud.StudentAddress.Address1 = "address444";
                    stud.StudentAddress.Address2 = "add222";
                    stud.StudentAddress.City = "city444";
                    stud.StudentAddress.State = "State444";
                }
                else if (stud.StudentAddress != null) // delete address
                    stud.StudentAddress = null;

            }

            //save modified entity using new context
            using (var dbCtx = new SchoolDBEntities())
            {
                StudentAddress existingStudentAddress = dbCtx.StudentAddresses.Where(addr => addr.StudentID == stud.StudentID).FirstOrDefault<StudentAddress>();
                
                //Mark each entity as modified
                dbCtx.Entry(stud).State = System.Data.EntityState.Modified;
                //dbCtx.Entry(stud.StudentAddress).State = System.Data.EntityState.Modified;

                if (existingStudentAddress != null)
                {
                    dbCtx.Entry<StudentAddress>(existingStudentAddress).State = System.Data.EntityState.Deleted;

                    if (stud.StudentAddress != null)
                        dbCtx.StudentAddresses.Add(stud.StudentAddress);
                }
                else
                {
                    dbCtx.StudentAddresses.Add(stud.StudentAddress);
                }
                
                
                if (dbCtx.GetValidationErrors().Count() <= 0)
                    dbCtx.SaveChanges();
            }

            Console.WriteLine("UpdateOneToOneEntity successfull");

        }

        public static void UpdateOneToManyEntity()
        {
            Student stud;
            // Get student from DB
            using (var ctx = new SchoolDBEntities())
            {
                ctx.Configuration.ProxyCreationEnabled = false;
                stud = ctx.Students.Where(s => s.StudentID == 1).Include(s => s.Standard.Teachers).FirstOrDefault<Student>();
            }

            var teachers = stud.Standard.Teachers.ToList<Teacher>();

            foreach (Teacher tchr in teachers)
            {
                tchr.TeacherName = "Updated " + tchr.TeacherName;
            }
            //add new teacher
            teachers.Add(new Teacher() { TeacherName = "New teacher4" });
            teachers.Add(new Teacher() { TeacherName = "New teacher5" });
            teachers.RemoveAt(1);

            using (var dbCtx = new SchoolDBEntities())
            {
                //Get fresh data from database
                var existingStudent = dbCtx.Students.AsNoTracking().Include(s => s.Standard).Include(s => s.Standard.Teachers).Where(s => s.StudentID == stud.StudentID).FirstOrDefault<Student>();

                var existingTeachers = existingStudent.Standard.Teachers.ToList<Teacher>();

                var updatedTeachers = teachers.ToList<Teacher>();
                //Find newly added teachers by updatedTeachers - existingTeacher = newly added teacher
                var addedTeachers = updatedTeachers.Except(existingTeachers, tchr => tchr.TeacherId);

                //Find deleted teachers by existing teachers - updatedTeachers = deleted teachers
                var deletedTeachers = existingTeachers.Except(updatedTeachers, tchr => tchr.TeacherId);

                //Find modified teachers by updatedTeachers - addedTeachers = modified teachers
                var modifiedTeacher = updatedTeachers.Except(addedTeachers, tchr => tchr.TeacherId);

                //Mark all added teachers entity state to Added
                addedTeachers.ToList<Teacher>().ForEach(tchr => dbCtx.Entry(tchr).State = System.Data.EntityState.Added);

                //Mark all deleted teacher entity state to Deleted
                deletedTeachers.ToList<Teacher>().ForEach(tchr => dbCtx.Entry(tchr).State = System.Data.EntityState.Deleted);


                //Apply modified teachers current property values to existing property values
                foreach(Teacher teacher in modifiedTeacher)
                {
                    //Find existing teacher by id from fresh database teachers
                   var existingTeacher = dbCtx.Teachers.Find(teacher.TeacherId);
                    
                    if (existingTeacher != null)
                    {
                        //Get DBEntityEntry object for each existing teacher entity
                        var teacherEntry = dbCtx.Entry(existingTeacher);
                        //overwrite all property current values from modified teachers' entity values, 
                        //so that it will have all modified values and mark entity as modified
                        teacherEntry.CurrentValues.SetValues(teacher);
                    }

                }
                //Save all above changed entities to the database
                dbCtx.SaveChanges();
            }


            Console.WriteLine("UpdateOneToOneEntity successfull");

        }

        public static void UpdateManyToManyEntity()
        {
            Student stud;
            IList<Course> courseList = null;
            // Get student from DB
            using (var ctx = new SchoolDBEntities())
            {
                stud = ctx.Students.Include("Courses").Where(s => s.StudentID == 1).FirstOrDefault<Student>();
                courseList = ctx.Courses.ToList<Course>();
            }



            if (stud.Courses != null)
            {

                Course cours = stud.Courses.FirstOrDefault<Course>();
                //removing first course from student's existing courses
                stud.Courses.Remove(cours);
            }

            //Add existing courses to student's course list
            if(stud.Courses.Count > 0)
            stud.Courses.Add(courseList[1]);
            //stud.Courses.Add(courseList[6]);

            using (var dbCtx = new SchoolDBEntities())
            {
                //Get existing data from database
                var existingStudent = dbCtx.Students.Include("Courses").Where(s => s.StudentID == stud.StudentID).FirstOrDefault<Student>();

                //Find deleted courses from student's course collection by students' existing courses (existing data from database) minus students' current course list (came from client in disconnected scenario)
                var deletedCourses = existingStudent.Courses.Except(stud.Courses, cours => cours.CourseId).ToList<Course>();

                //Find Added courses in student's course collection by students' current course list (came from client in disconnected scenario) minus students' existing courses (existing data from database) - 
                var addedCourses = stud.Courses.Except(existingStudent.Courses, cours => cours.CourseId).ToList<Course>();

                //Remove deleted courses from students' existing course collection (existing data from database)
                deletedCourses.ForEach(c => existingStudent.Courses.Remove(c));
                
                //Add new courses
                foreach(Course c in addedCourses)
                {
                    //Attach courses because it came from client as detached state in disconnected scenario
                    if (dbCtx.Entry(c).State == System.Data.EntityState.Detached)
                        dbCtx.Courses.Attach(c);

                    //Add course in existing student's course collection
                    existingStudent.Courses.Add(c);
                }
                //Save changes which will reflect in StudentCourse table only
                dbCtx.SaveChanges();
            }

            Console.WriteLine("UpdateOneToOneEntity successfull");

        }
    }
}
