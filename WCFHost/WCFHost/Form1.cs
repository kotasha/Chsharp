using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace WCFHost
{
    public partial class Form1 : Form
    {
        ServiceHost host;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Type t = typeof(CalcInterestService.CalcAgentInterestSevice);
            Uri httpUrl = new Uri("http://localhost:9090/Ganesha");
            // Create Service host
            host = new ServiceHost(t, httpUrl);// t is the what type u r going to use and httpUrl is Where the service is available
            // Add endpoints
            // this binding is general in wcf webservice between a client and a server
            host.AddServiceEndpoint(typeof(CalcInterestService.IAgentIntCalcService),new WSHttpBinding(),"siddi");
            // this binding is used in xml webservices
            host.AddServiceEndpoint(typeof(CalcInterestService.IAgentIntCalcService), new BasicHttpBinding(), "Buddi");
            // Duplex communication with the following type of binding is used where server and Client both act as vice versa
            host.AddServiceEndpoint(typeof(CalcInterestService.IAgentIntCalcService), new WSDualHttpBinding(), "xyz");
            // metada exchange or metadata endpoint creation
            // mex endpoint known as a non service endpoint
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;

            host.Description.Behaviors.Add(smb);

            host.Open();
            label1.Text= " Service is hosted at"+ DateTime.Now.ToString() +"click stop button to stop the service" ;
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
           host.Close();
           label2.Text = "Click start button to start the service";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ServiceHost host = new ServiceHost(typeof(CalcInterestService.CalcAgentInterestSevice));

            host.Open();
            label1.Text = " Service is hosted at" + DateTime.Now.ToString() + "click stop button to stop the service";

        }
    }
}
