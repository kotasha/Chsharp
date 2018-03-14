using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsoleApp.Interfaces;

namespace TestConsoleApp.Classes
{
    public class Customer : IBusinessInterface
    {
        public Customer()
        {
            Console.WriteLine("in customer");
        }
    }
}
