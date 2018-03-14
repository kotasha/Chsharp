using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace DBEntries
{
    public class NewDbContext : DbContext
    {
        public NewDbContext()
            : base("name=MyProductContext")
        {
        }
        public DbSet<AssertionTypes> AssertionType { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AssertionTypes>().HasKey(s => s.numAssertionTypeId);
        }
    }
}
