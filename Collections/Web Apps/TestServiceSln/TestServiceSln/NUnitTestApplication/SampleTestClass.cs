using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace NUnitTestApplication
{
    [TestFixture]
    public class SampleTestClass
    {
        [Test]
        public void SampleTestMethod()
        {
            ArithmaticOperations obj = new ArithmaticOperations();
            int i = obj.Divide(3,1);

            Assert.AreEqual(3, i);
        }
    }
}
