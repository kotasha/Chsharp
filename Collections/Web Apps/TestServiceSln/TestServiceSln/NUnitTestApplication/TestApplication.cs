using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnitTestApplication.RealServiceReference;
//using NUnitTestApplication.RealServerServiceReference;

namespace NUnitTestApplication
{
    [TestFixture]
    public class TestApplication
    {
        ArithmaticOperations obj;
        [SetUp]
        public void Init()
        {
            obj = new ArithmaticOperations();
        }
        [Test]
        //[ExpectedException]
        public void TestMethod()
        {
            int i = obj.Divide(3, 1);
            Assert.AreEqual(3, i);
            Console.WriteLine(i);
        }
        [Test]
        public void TestListMethod()
        {
            List<int> myList = obj.GetList();
            Assert.Contains(2, myList);
            
        }
        [Test]
        public void TestPersonListMethod()
        {
            List<Person> myList = obj.GetPersons();
            List<Person> per = new List<Person>(){
            //Person per = 
            new Person { 
                Name = "Person1", Gender = "Male" }};

            Assert.Contains(per, myList);
            //Assert.That(myList, Is.EqualTo(per));

            //CollectionAssert.IsSubsetOf(per,myList);
        }
        [Test]
        public void TestPersonMethod()
        {
            Person myList = obj.GetPerson();
            Person per = new Person { Name = "Person1", Gender = "Male" };

            //Assert.AreEqual(per.Name, myList.Name);
            //Assert.AreEqual(per.Gender, myList.Gender);
            AssertionHelper.Equals(myList, per);
            //Assert.That(myList.Name, Is.EqualTo(per.Name));
        }
    }
    [TestFixture]
    public class TestServiceApplication
    {
        [Test]
        //[ExpectedException]
        public void TestLocalServiceMethod()
        {
            TestServiceClient objService = new TestServiceClient("WSHttpBinding_ITestService");
            string str = objService.DoWork();
            //ArithmaticOperations obj = new ArithmaticOperations();
            //int i = obj.Divide(2, 1);
            Console.WriteLine("TestLocalServiceMethod output :" +str);
        }
    }
}
