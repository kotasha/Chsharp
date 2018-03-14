using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsoleApp.Classes;
using TestConsoleApp.Interfaces;

namespace TestConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                IBusinessInterface myObj = BusinessFactoryClass.CreateInstance<IBusinessInterface>(ObjectType.Employee);
                //Console.Read();
            }
            catch (Exception obj)
            {
                obj.Log();
            }
            Console.Read();
        }
    }
}
