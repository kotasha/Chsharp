using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass obj = new MyClass();
            obj.method();
        }
    }
    public class MyClass : Class1, IComparable
    {
        public int method<T>() where T: System.IComparable<T>
        {
            return 1;
        }

        int IComparable.CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public override void method2()
        {
            throw new NotImplementedException();
        }
    }
    public abstract class Class1
    {
        public void method()
        {
        }
        public abstract void method2();
    }
}
