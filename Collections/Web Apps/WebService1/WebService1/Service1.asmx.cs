using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

namespace WebService1
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Service1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public string MyWord(string strCheck)
        {
            return strCheck;
        }
        [WebMethod]
        public Customer MyObject(string id, string name)
        {
            Customer objCust = new Customer(name, id);
            return objCust;
        }
    }
    public class Customer
    {
        public Customer()
        {
        }
        public Customer(string name, string id)
        {
            Name = name;
            EmpID = id;
        }
        public string Name { get; set; }
        public string EmpID { get; set; }
    }
}