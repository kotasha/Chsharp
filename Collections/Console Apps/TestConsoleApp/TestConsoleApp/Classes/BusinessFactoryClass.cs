using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsoleApp.Interfaces;

namespace TestConsoleApp.Classes
{
    public static class BusinessFactoryClass
    {
        //BusinessFactoryClass myObject = default(BusinessFactoryClass);
        
        public static T CreateInstance<T>(ObjectType enumobj) where T : IBusinessInterface
        {
            IBusinessInterface business = default (IBusinessInterface);

            switch (enumobj)
            {
                case ObjectType.Customer:
                    business = new Customer();
                    break;
                case ObjectType.Employee:
                    business = new Employee();
                    break;
                default:
                    throw new Exception("Class Not Implemented");
            }

            return (T)business;
        }
        public static string Log(this Exception exp)
        {
            //exp = new Exception();
            //return string.Format(@" exception : {0} with message {1} occured", exp.InnerException.ToString(), exp.Message);
            return default(string);
        }
    }
}
