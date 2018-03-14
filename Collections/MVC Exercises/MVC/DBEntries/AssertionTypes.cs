using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer;

namespace DBEntries
{
    public class AssertionTypes : IBusinessLayer
    {
        public string txtAssertionTypeDescription { get; set; }
        public string txtAssertionTypeDisplayCode { get; set; }
        public string txtAssertionTypeCode { get; set; }
        public int numAssertionTypeId { get; set; }

        public override string ToString()
        {
            return string.Format("Assertions : {0}_{1}_{2}_{3}", numAssertionTypeId.ToString(), txtAssertionTypeCode, txtAssertionTypeDescription, txtAssertionTypeDisplayCode);
        }
    }
}
