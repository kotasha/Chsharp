using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsoleApp.Interfaces;

namespace TestConsoleApp.Classes
{
    public class Employee : IBusinessInterface
    {
        public Employee()
        {
            Console.WriteLine("in employee");
        }
    }
}
