using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "IAgentIntCalcServiceTest" in code, svc and config file together.
    public class IAgentIntCalcServiceTest : IIAgentIntCalcServiceTest
    {
        public int AgentIntCal(int a, int b)
        {
            int AgentInterest;
            AgentInterest = a * b / 100;

            return AgentInterest;

        }
    }
}
