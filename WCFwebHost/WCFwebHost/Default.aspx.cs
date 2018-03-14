using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ServiceModel;
using System.ServiceModel.Description;
using ServiceReference1;

namespace WCFwebHost
{
    public partial class _Default : System.Web.UI.Page
    {
        //ServiceHost host;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Type t = typeof(CalcInterestService.CalcAgentInterestSevice);
            //Uri httpUrl = new Uri("http://localhostB/Ganesha");
            //// Create Service host
            //host = new ServiceHost(t, httpUrl);// t is the what type u r going to use and httpUrl is Where the service is available
            //// Add endpoints
            //// this binding is general in wcf webservice between a client and a server
            //host.AddServiceEndpoint(typeof(CalcInterestService.IAgentIntCalcService), new WSHttpBinding(), "siddi");
            //// this binding is used in xml webservices
            //host.AddServiceEndpoint(typeof(CalcInterestService.IAgentIntCalcService), new BasicHttpBinding(), "Buddi");
            //// Duplex communication with the following type of binding is used where server and Client both act as vice versa
            //host.AddServiceEndpoint(typeof(CalcInterestService.IAgentIntCalcService), new WSDualHttpBinding(), "xyz");
            //// metada exchange or metadata endpoint creation
            //// mex endpoint known as a non service endpoint
            //ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            //smb.HttpGetEnabled = true;

            //host.Description.Behaviors.Add(smb);

            //host.Open();

        }
        protected void Page_OnUnLoad(object sender, EventArgs e)
        {
            //host.Close();
        }
    }
}