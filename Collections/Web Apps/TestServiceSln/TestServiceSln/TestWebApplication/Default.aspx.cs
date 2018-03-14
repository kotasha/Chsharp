using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestWebApplication.RealServiceReference;
using System.ServiceModel;
using Microsoft.Build.Framework;
using System.Diagnostics;

namespace TestWebApplication
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void myButton_Click(object sender, EventArgs e)
        {
            try
            {
                //throw new HttpException(402, "custom error");
                TestServiceClient objClient = new TestServiceClient("WSHttpBinding_ITestService");
                string str = objClient.DoWork();
            }
            catch (FaultException<Faults> Fex)
            {
                EventLog Log = new EventLog();
                Log.Source = "TestWebApplication";
                Log.WriteEntry(string.Format(@"{0} has raised exception of {1} type with {2} {3}", Log.Source, "Service", Fex.Detail, Fex.Message), EventLogEntryType.Error);
            }
            finally
            {
            }
        }
    }
    
}
