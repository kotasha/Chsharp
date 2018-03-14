using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBEntries;
using System.Configuration;

namespace TestConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //string CONN_STRING = ConfigurationSettings.AppSettings[""].ToString();
            //using(var myDb = new NewDbContext())
            //{
            //    var col = myDb.AssertionType;

            //    foreach (var item in col)
            //    {
            //        Console.WriteLine(item.ToString());
            //    }
            //}
            Console.WriteLine("--------------------------------------");
            using (var db = new MyDbContext())
            {
                try
                {
                    var title = db.Books;
                    foreach (var item in title)
                    {
                        Console.WriteLine(item.ToString());
                    }
                    var col = db.AssertionType;
                    Console.WriteLine("--------------------------------------");
                    foreach (var item in col)
                    {
                        Console.WriteLine(item.ToString());
                    }
                    Console.Read();
                }
                catch { }
            }
            Console.Read();
        }
    }
}
