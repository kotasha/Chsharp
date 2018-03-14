using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceApplication
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TestService" in code, svc and config file together.
    [ServiceBehavior(Name = "Test1")]
    public class TestService : ITestService
    {
        public string DoWork()
        {
            return "In Test 1";
        }
    }
   
    //public class RealService : ITestService
    //{
    //    public string DoWork()
    //    {
    //        return "In Test 2";
    //    }
    //}
}
