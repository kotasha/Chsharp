using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebService1;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        //public void TestMethod1()
        //{
        //    //WebService1.Service1 obj = new WebService1.Service1();
        //    //string check = obj.MyWord("check");
        //}

        [TestMethod]
        public void TestMethod2()
        {
            //WebService1.Service1 obj = new WebService1.Service1();
            Service1 obj = new Service1();
            string check = obj.MyWord("check");
        }
    }
}
