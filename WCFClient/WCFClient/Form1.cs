using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WCFClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.AgentIntCalcServiceClient obj = new ServiceReference1.AgentIntCalcServiceClient("WSHttpBinding_IAgentIntCalcService");
            int AgentBonus=obj.AgentIntCal(Convert.ToInt16(textBox1.Text), Convert.ToInt16(textBox2.Text));
            MessageBox.Show(AgentBonus +"");
        }
    }
}
