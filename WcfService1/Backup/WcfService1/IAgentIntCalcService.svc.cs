using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{

    [DataContract]
    public class CalcAgentInterestSevice : IAgentIntCalcService
    {

        public int AgentIntCal(int a, int b)
        {
            int AgentInterest;
            AgentInterest = a * b / 100;

            return AgentInterest;

        }

    }
}
