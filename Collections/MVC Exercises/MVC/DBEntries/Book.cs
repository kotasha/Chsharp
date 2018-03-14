using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBEntries
{
    public class Books : IBusinessLayer
    {
        [Column("txtBookName")]
        public string BookName { get; set; }
        [Column("txtAcronym")]
        public string Acronym { get; set; }
        [Column("txtBusinessCode")]
        public string BusinessCode { get; set; }
        [Column("txtBookYear")]
        public string BookYear { get; set; }
        [Column("uidBookID")]
        public Guid BookID { get; set; }

        public override string ToString()
        {
            return string.Format("{0} _ {1} _ {2} _ {3} ", Acronym, BusinessCode,  BookName, BookYear);
        }
    }
}
