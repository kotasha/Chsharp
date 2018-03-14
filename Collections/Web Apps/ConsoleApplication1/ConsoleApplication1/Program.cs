using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public delegate void MyDel(int i);

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                #region Moniter.Enter Sample
                
                MonitorSample sample = new MonitorSample();

                for (int i = 0; i < 30; i++)
                    sample.AddElement(i);
                sample.PrintAllElements();
                sample.DeleteElement(0);
                sample.DeleteElement(10);
                sample.DeleteElement(20);
                sample.PrintAllElements();
                #endregion

                #region event sample

                //Run objRun = new Run();
                //A a = new A(objRun);
                //B b = new B(objRun);
                //C c = new C(objRun);
                

                //objRun.Display();
                #endregion

                //AsyncSample objAsyc = new AsyncSample();
                //objAsyc.Display();

                #region - Async mail sample

                //SendMailAsync objSend = new SendMailAsync();
                //objSend.Display();
                
                #endregion
                string q = Console.ReadLine();
            }
            catch (ArithmeticException objEx)
            {
            }
            catch (Exception obj)
            {
            }
            catch { }

        }
    }
    public class Run
    {
        public event MyDel MyEvent;

        public void Display()
        {
            if (MyEvent != null)
            {
                MyEvent(10);
            }
        }
    }
    public class A
    {
        public A(Run run)
        {
            run.MyEvent += new MyDel(display);
        }
        public void display(int i)
        {
            Console.WriteLine("In A with square " + (i * i).ToString());
        }

    }
    public class B
    {
        public B(Run run)
        {
            run.MyEvent += new MyDel(display);
        }
        public void display(int i)
        {
            Console.WriteLine("In B with cube " + (i * i * i).ToString());
        }

    }
    public class C
    {
        public C(Run run)
        {
            run.MyEvent += new MyDel(display);
        }
        public void display(int i)
        {
            Console.WriteLine("In C");
        }

    }


    //public class B : A
    //{
    //    public override string Method()
    //    {
    //        return "B";
    //    }
    //}
    //public class C : B
    //{
    //    public new string Method()
    //    {
    //        return "C";
    //    }
    //}
}
