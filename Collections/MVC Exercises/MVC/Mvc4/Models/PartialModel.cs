using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc4.Models
{
    public partial class PartialModel
    {
        public string Name { get; set; }
        public int Actual { get; set; }
        public int Target { get; set; }
        public int Score { get; set; }
    }
    public partial class PartialModel
    {
        public List<PartialModel> lstPartialModel { get; set; }

    }
}