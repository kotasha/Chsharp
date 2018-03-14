using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Configuration;

namespace DBEntries
{
    public class MyDbContext : DbContext
    {
        private static string CONN_STRING = ConfigurationManager.ConnectionStrings["MyProductContext"].ConnectionString;

        public MyDbContext()
            : base(CONN_STRING)
        {
        }
        public DbSet<Books> Books { get; set; }
        public DbSet<AssertionTypes> AssertionType { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Configurations.Add<Books>(new BookMappingClass());

            modelBuilder.Entity<Books>().HasKey(s => s.BookID);
            modelBuilder.Entity<AssertionTypes>().HasKey(s => s.numAssertionTypeId);
        }
    }
}
