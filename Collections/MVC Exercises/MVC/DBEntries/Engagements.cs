using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBEntries
{
    public class Engagements
    {
        public string txtBookName { get; set; }
        public string txtAcronym { get; set; }
        public string txtBusinessCode { get; set; }
        public string txtBookYear { get; set; }
        public Guid uidEngagementId { get; set; }
    }
}
