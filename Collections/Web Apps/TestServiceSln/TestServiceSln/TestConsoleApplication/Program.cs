using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.ServiceModel;
//using TestConsoleApplication.RealServiceReference;
using TestConsoleApplication.RealServiceReferenceLocal;

namespace TestConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                TestServiceClient objClient = new TestServiceClient("WSHttpBinding_ITestService1");
                Console.WriteLine(objClient.DoWork());
            }
            catch (FaultException<Faults> Fex)
            {
                EventLog Log = new EventLog();
                Log.Source = "TestConsoleApplication";
                Log.WriteEntry(string.Format(@"{0} has raised exception of {1} type with {2} {3}",Log.Source, "Service", Fex.Detail, Fex.Message), EventLogEntryType.Error);
            }
        }
    }
}
