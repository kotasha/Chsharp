using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Web;

namespace WcfServiceApplication
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RealService" in code, svc and config file together.
    [ServiceBehavior(Name = "Test2")]
    public class RealService : ITestService
    {
        public string DoWork()
        {
            try
            {
                //throw new Exception("My Error");
                //Thread.Sleep(10000);
                return "In Test 2";
            }
            catch (Exception obj)
            {
                Faults objEx = new Faults();
                objEx.FaultType = "ServiceException";
                objEx.Details = (obj.InnerException != null) ? obj.InnerException.Message : default(string);
                objEx.Message = obj.Message;

                throw new FaultException<Faults>(objEx,obj.ToString());
            }
        }
    }
    [DataContract]
    public class Faults
    {
        [DataMember]
        public string FaultType { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string Details { get; set; }
    }
    
}
