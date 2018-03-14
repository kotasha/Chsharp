using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Data.Objects;

namespace EFDBContext
{
    class MiscDemo
    {
        public MiscDemo() { }

        public static void FindEntityDemo()
        {
            using (var ctx = new SchoolDBEntities())
            {
                var stud = ctx.Teachers.Find(1);

                Console.WriteLine(stud.TeacherName + " found");

            }
            Console.WriteLine("FindEntityDemo Successfull");
        }

        public static void GetPropertyValues()
        {

            using (var ctx = new SchoolDBEntities())
            {
                var stud = ctx.Students.Include(sadd => sadd.StudentAddress).Where(s => s.StudentName == "updated student").FirstOrDefault<Student>();
                stud.StudentName = "Changed Student Name";

                //Get reference reference property eg. foerignkey entity (single entity)
                var referenceProperty = ctx.Entry(stud).Reference(s => s.Standard);  //.Property(s =>s.StudentAddress).ParentProperty;
                
                //get collection navigation property information (one-to-many or many-to-many property) eg. Student.Courses
                var collectionProperty = ctx.Entry(stud).Collection<Course>(s => s.Courses);

                //var complexProperty = ctx.Entry(stud).ComplexProperty(stud.StudentStandard);  
                
                string propertyName = ctx.Entry(stud).Property("StudentName").Name;
                string currentValue = ctx.Entry(stud).Property("StudentName").CurrentValue.ToString();
                string originalValue = ctx.Entry(stud).Property("StudentName").OriginalValue.ToString();
                bool isChanged = ctx.Entry(stud).Property("StudentName").IsModified;
                var dbEntity = ctx.Entry(stud).Property("StudentName").EntityEntry;

                Console.WriteLine("****GetPropertyValues Start: ");
                Console.WriteLine("Property Name:" + propertyName);
                Console.WriteLine("current value:" + currentValue);
                Console.WriteLine("original value:" + originalValue);
                Console.WriteLine("isModified:" + isChanged.ToString());
                Console.WriteLine("****GetPropertyValues End: ");
                
            
            }        
        }


        public static void SetValuesDemo()
        {
            StudentDTO studDTO = new StudentDTO();
            studDTO.StudentName = "StudentName from DTO";
            
            using (var ctx = new SchoolDBEntities())
            {                
                var stud = ctx.Students.Find(1);
                
                var studEntry = ctx.Entry(stud);
                studEntry.CurrentValues.SetValues(studDTO);
                Console.WriteLine("****SetValuesDemo Start: ");
                
                foreach (var propertyName in studEntry.CurrentValues.PropertyNames)
                {
                    Console.WriteLine("Property {0} has value {1}",
                                      propertyName, studEntry.CurrentValues[propertyName]);
                }
                Console.WriteLine("****SetValuesDemo End: ");
            
            }

        
        }

        public static void DBContextSetMethod()
        {
            using (var ctx = new SchoolDBEntities())
            {
                var stud = ctx.Students.Find(1);


                ctx.Set(stud.GetType().BaseType).Add(stud);
                ctx.Set(stud.GetType().BaseType).Attach(stud);
                ctx.Set(stud.GetType().BaseType).Remove(stud);
                var sql = ctx.Set(stud.GetType().BaseType).SqlQuery("select * from student");

                ctx.Set<Student>().Add(stud);
                ctx.Set<Student>().Attach(stud);
                ctx.Set<Student>().Remove(stud);

                ctx.Students.Add(stud);
                ctx.Students.Attach(stud);
                ctx.Students.Remove(stud);
                ctx.Students.SqlQuery("select * from student");
            }

            Console.WriteLine("DBContextSetMethod Successfull ");

        }
        public static void DBContextGenricSetMethod()
        {
            using (var ctx = new SchoolDBEntities())
            {
                var stud = ctx.Students.Find(1);
                ctx.Set<Student>().Add(stud);
                ctx.Set<Student>().Attach(stud);
                ctx.Set<Student>().Remove(stud);
                var result = ctx.Set<Student>().SqlQuery("select * from student");

                //Result would be same as following
                //ctx.Students.Add(stud);
                //ctx.Students.Attach(stud);
                //ctx.Students.Remove(stud);
                //ctx.Students.SqlQuery("select * from student");
            }
            Console.WriteLine("DBContextGenricSetMethod Successfull ");
        }

        public static void LocalDemo()
        {
            using (var ctx = new SchoolDBEntities())
            {
                ctx.Students.Load();
                ctx.Students.Add(new Student() { StudentName = "New Student1" });

                ctx.Students.Remove(ctx.Students.Find(1));
                
                
                // Loop over the unicorns in the context.
                Console.WriteLine("***In Local: ");
                foreach (var student in ctx.Students.Local)
                {
                    Console.WriteLine("Found {0}: {1} with state {2}",
                                      student.StudentID, student.StudentName,
                                      ctx.Entry(student).State);
                }

                // Perform a query against the database.
                Console.WriteLine("\n***In DbSet query: ");
                foreach (var student in ctx.Students)
                {
                    Console.WriteLine("Found {0}: {1} with state {2}",
                                      student.StudentID, student.StudentName,
                                      ctx.Entry(student).State);
                }
                Console.WriteLine("***LocalDemo Successfull");

            }
        }

        public static void ValidationErrorDemo()
        {
            try
            {
                using (var ctx = new SchoolDBEntities())
                {
                    ctx.Students.Add(new Student() { StudentName = "" });
                    ctx.Standards.Add(new Standard() { StandardName = "" });
                    
                    Console.WriteLine("***ValidationErrorDemo Start");

                    ctx.SaveChanges();


                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (DbEntityValidationResult entityErr in dbEx.EntityValidationErrors)
                {
                    foreach (DbValidationError error in entityErr.ValidationErrors)
                    {
                        Console.WriteLine("Error Property Name {0} : Error Message: {1}",
                                          error.PropertyName, error.ErrorMessage);
                    }
                }
                Console.WriteLine("***ValidationErrorDemo End");
            }
        }


        public static void LazyLoadingDemo()
        {
            // Get student from DB
            using (var ctx = new SchoolDBEntities())
            {

                //Loading students only
                IList<Student> studList = ctx.Students.ToList<Student>();

                Student student = studList[0];

               //Loads Student address for particular Student only (seperate SQL query)
                Standard std = student.Standard;
            }
            Console.WriteLine("LazyLoadingDemo Successfull");
        }

        public static void ExplicitLoadingDemo()
        {
            // Get student from DB
            using (var ctx = new SchoolDBEntities())
            {
                //Loading students only
                IList<Student> studList = ctx.Students.ToList<Student>();

                Student std = studList[0];

                //Loads Standard for particular Student only (seperate SQL query)
                ctx.Entry(std).Reference(s => s.Standard).Load();

                //Loads Courses for particular Student only (seperate SQL query)
                ctx.Entry(std).Collection(s => s.Courses).Load();
            }

            Console.WriteLine("ExplicitLoadingDemo Successfull");
        }

        public static void QueryMethodDemo()
        {
            // Get student from DB
            using (var ctx = new SchoolDBEntities())
            {
                //Loading students only
                IList<Student> studList = ctx.Students.ToList<Student>();

                Student std = studList[0];
                //count courses without loading
                var CourseCount = ctx.Entry(std).Collection(s => s.Courses).Query().Count<Course>();

                //Loads Courses for particular Student only (seperate SQL query)
                ctx.Entry(std).Collection(s => s.Courses).Query().Where<Course>(c => c.CourseName == "New Course1").Load();
            }

            Console.WriteLine("QueryMethodDemo Successfull");
        }
        public static void POCOProxyDemo()
        {
            using (var ctx = new SchoolDBEntities())
            {
                //getting POCO Proxy object
                var studentPOCOProxy = ctx.Students.Find(1);
                
                //get actual type of POCO Proxy object
                Type pocoType = studentPOCOProxy.GetType().BaseType;

                //Disable Proxy creation
                ctx.Configuration.ProxyCreationEnabled = false;

                //Getting POCO object (Plain Old CLR Object)
                Student stdPOCO = ctx.Students.Find(1);

            }
            Console.WriteLine("POCOProxyDemo Successfull");
        }

        public static void RawSQLtoEntityTypeDemo()
        {
            using (var ctx = new SchoolDBEntities())
            {
                var studentList = ctx.Students.SqlQuery("Select * from Student").ToList<Student>();

                var studentName = ctx.Students.SqlQuery("Select studentid, studentname from Student where studentname='New Student1'").ToList();

            }
            Console.WriteLine("RawSQLtoEntityTypeDemo Successfull");
        }

        public static void RawSQLCommandDemo()
        {
            using (var ctx = new SchoolDBEntities())
            {
                //Get student name of string type
                string standardName = ctx.Database.SqlQuery<string>("Select standardName from Standard where standardid=1").FirstOrDefault<string>();

                //Update command
                int noOfRowUpdate = ctx.Database.ExecuteSqlCommand("Update student set studentname ='changed student by command' where studentid=1");
                //Insert command
                int noOfRowInsert = ctx.Database.ExecuteSqlCommand("insert into student(studentname) values('New Student')");
                //Delete command
                int noOfRowDeleted = ctx.Database.ExecuteSqlCommand("delete from student where studentid=1");

            }
            Console.WriteLine("RawSQLCommandDemo Successfull");
        }

        public static void StoredProcedureDemo()
        {
            using (var ctx = new SchoolDBEntities())
            {
                //Execute stored procedure as a function
                var courseList = ctx.GetCoursesByStudentId(1).ToList<Course>();
               
                //Alternate method to execute stored procedure
                //var idParam = new SqlParameter {
                //         ParameterName = "StudentID",
                //         Value = 1
                //};
                ////Get student name of string type
                //var courseList = ctx.Database.SqlQuery<Course>("exec GetCoursesByStudentId @StudentId ", idParam).ToList<Course>();
                
                //Or can call SP by following way
                //var courseList = ctx.Courses.SqlQuery("exec GetCoursesByStudentId @StudentId ", idParam).ToList<Course>();

                foreach (Course cs in courseList)
                    Console.WriteLine("Course Name: {0}",cs.CourseName);
            }
            Console.WriteLine("StoredProcedureDemo Successfull");
        }
    }

    public class StudentDTO
    {
        public StudentDTO() { }

        //public int StudentID { get; set; }
        public string StudentName { get; set; }
    }
}
