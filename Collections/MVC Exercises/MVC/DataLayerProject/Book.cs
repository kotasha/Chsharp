using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayerProject
{
    public class Book
    {
        public Guid BookID { get; set; }
        public string BookName { get; set; }
        public string Acronym { get; set; }
        public string BusinessCode { get; set; }
        public string BookYear { get; set; }

    }
}
