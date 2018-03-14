using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFDBContext
{
    public class AddEntityDemo
    {
        public AddEntityDemo() { }

        public static void AddEntity()
        {
            // create new Standard entity object
            var newStandard = new Standard();

            // Assign standard name
            newStandard.StandardName = "Standard 1";

            //create DBContext object
            using (var dbCtx = new SchoolDBEntities())
            {
                //Add standard object into Standard DBset
                dbCtx.Standards.Add(newStandard);
                // call SaveChanges method to save standard into database
                dbCtx.SaveChanges();
            }

            Console.WriteLine("AddEntity successfull");

        }

        public static void AddOneToOneEntity()
        {
            // create new student entity object
            var student = new Student();

            // Assign student name
            student.StudentName = "New Student1";

            // Create new StudentAddress entity and assign it to student entity
            student.StudentAddress = new StudentAddress() { Address1 = "Student1's Address1", Address2 = "Student1's Address2", City = "Student1's City", State = "Student1's State" };

            //create DBContext object
            using (var dbCtx = new SchoolDBEntities())
            {
                //Add student object into Student's EntitySet
                dbCtx.Students.Add(student);
                //Alternate method of adding one-to-one entity graph
                //dbCtx.Entry(student).State = System.Data.EntityState.Added;
                // call SaveChanges method to save student & StudentAddress into database
                dbCtx.SaveChanges();
            }

            Console.WriteLine("AddOneToOneEntity successfull");

        }

        public static void AddOneToManyEntity()
        {
            //Create new standard
            var standard = new Standard();
            standard.StandardName = "Standard1";

            //create new teachers
            var teacher1 = new Teacher();
            teacher1.TeacherName = "New Teacher1";
            
            var teacher2 = new Teacher();
            teacher2.TeacherName = "New Teacher2";
            
            var teacher3 = new Teacher();
            teacher3.TeacherName = "New Teacher3";

            //add teachers for new standard
            standard.Teachers.Add(teacher1);
            standard.Teachers.Add(teacher2);
            standard.Teachers.Add(teacher3);

            using (var dbCtx = new SchoolDBEntities())
            {
                //add standard entity into standards entitySet
                dbCtx.Standards.Add(standard);
                //Save whole entity graph to the database
                dbCtx.SaveChanges();
            }
            Console.WriteLine("AddOneToManyEntity successfull");

        }

        public static void AddManyToManyEntity()
        {
            //Create student entity
            var student1 = new Student();
            student1.StudentName = "New Student2";
            //Standard std = new Standard() { StandardName = "New Standard2" };
            //student1.Standard = std;

            //var student2 = new Student();
            //student2.StudentName = "New Student3";
            //student2.Standard = std;

            //Create course entities
            var course1 = new Course();
            course1.CourseName = "New Course1";
            course1.Location = "City1";

            var course2 = new Course();
            course2.CourseName = "New Course2";
            course2.Location = "City2";

            var course3 = new Course();
            course3.CourseName = "New Course3";
            course3.Location = "City1";

            //var teacher1 = new Teacher();
            //teacher1.TeacherName = "New teacher4";

            ////assign teacher1 for each courses
            //course1.Teacher = teacher1;
            //course2.Teacher = teacher1;
            //course3.Teacher = teacher1;

            // add multiple courses for student entity
            student1.Courses.Add(course1);
            student1.Courses.Add(course2);
            student1.Courses.Add(course3);

            //student2.Courses.Add(course2);


            using (var dbCtx = new SchoolDBEntities())
            {
                //add student into DBContext
                dbCtx.Students.Add(student1);
                //dbCtx.Students.Add(student2);

                //Alternate method of adding entity into DBContext
                //dbCtx.Entry(student1).State = System.Data.EntityState.Added;

                //call SaveChanges
                dbCtx.SaveChanges();
            }

            Console.WriteLine("AddManyToManyEntity successfull");

        }
    }
}
