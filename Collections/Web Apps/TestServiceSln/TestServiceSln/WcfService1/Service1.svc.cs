using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class Service1 : IService1
    {
        [OperationBehavior(Impersonation= ImpersonationOption.Allowed)]
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
        public string GetData1(int value)
        {
            return string.Format("You entered: {0}", value);
        }
        public string GetData2(int value)
        {
            return string.Format("You entered: {0}", value);
        }
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
    public class Service2 : IService1
    {
        [OperationBehavior(Impersonation = ImpersonationOption.Allowed)]
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
        public string GetData1(int value)
        {
            return string.Format("You entered: {0}", value);
        }
        public string GetData2(int value)
        {
            return string.Format("You entered: {0}", value);
        }
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
