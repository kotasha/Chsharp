using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Guid g = Guid.NewGuid();
            string str = g.ToString();
        }
    }
}
