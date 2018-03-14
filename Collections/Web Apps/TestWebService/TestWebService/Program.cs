using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestWebService.TestServiceReference;

namespace TestWebService
{
    class Program
    {
        public static void Main(string[] args)
        {
            TestServiceClient objClient = new TestServiceClient();
            Console.WriteLine(objClient.DoWork());

            Console.Read();
        }
    }
}
