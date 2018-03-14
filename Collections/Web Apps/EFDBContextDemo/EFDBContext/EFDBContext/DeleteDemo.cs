using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace EFDBContext
{
    public class DeleteDemo
    {
        public DeleteDemo() { }

        public static void DeleteEntity()
        {
            Teacher tchr ;
            // Get student from DB
            using (var ctx = new SchoolDBEntities())
            {
                tchr = ctx.Teachers.Where(t => t.TeacherName == "Teacher 1").FirstOrDefault<Teacher>();
            }

            
            //Delete entity using new context
            using (var dbCtx = new SchoolDBEntities())
            {
                if (tchr != null)
                {
                    //if already loaded in existing DBContext then use Set().Remove(entity) to delete it.
                    var newtchr = dbCtx.Teachers.Where(t => t.TeacherId == tchr.TeacherId).FirstOrDefault<Teacher>();
                    dbCtx.Set<Teacher>().Remove(newtchr);
                    //dbCtx.Teachers.Remove(newtchr);

                    //Mark entity as deleted
                    //dbCtx.Entry(tchr).State = System.Data.EntityState.Deleted;    

                    dbCtx.SaveChanges();
                }
            }

            Console.WriteLine("DeleteEntity Successfull");

        }


      
    }
}
