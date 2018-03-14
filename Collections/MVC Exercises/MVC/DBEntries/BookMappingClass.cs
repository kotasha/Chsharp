using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq.Expressions;

namespace DBEntries
{
    public class BookMappingClass : EntityTypeConfiguration<Books>
    {
        public BookMappingClass()
        {
            this.HasKey(d => d.BookID);
        }
    }
}
