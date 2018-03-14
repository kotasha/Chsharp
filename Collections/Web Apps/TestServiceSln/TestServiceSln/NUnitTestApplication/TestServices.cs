using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnitTestApplication.RealServerServiceReference;

namespace NUnitTestApplication
{
    [TestFixture]
    public class TestServices
    {
        [Test]
        public void TestServerServiceMethod()
        {
            TestServiceClient objService = new TestServiceClient("WSHttpBinding_ITestService1");
            string str = objService.DoWork();
            //ArithmaticOperations obj = new ArithmaticOperations();
            //int i = obj.Divide(2, 1);
            Console.WriteLine("TestLocalServiceMethod output :" + str);
        }
    }
}
