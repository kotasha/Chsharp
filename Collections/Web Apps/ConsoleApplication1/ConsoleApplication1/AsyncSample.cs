using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplication1
{
    public class AsyncSample
    {
        public delegate int MyDel(int i, int j);

        public void Display()
        {
            MyDel del = new MyDel(Add);
            IAsyncResult async = del.BeginInvoke(10, 20, new AsyncCallback(Callback), null);
            if(!async.AsyncWaitHandle.WaitOne(2000,true))
            {
                IAsyncResult async2 = del.BeginInvoke(20, 30, new AsyncCallback(Callback2), null);
                Thread.Sleep(2000);
                Console.WriteLine(del.EndInvoke(async2));
                Console.WriteLine("2nd thread completed");
            }
            Console.WriteLine(del.EndInvoke(async));
            Console.Read();

        }
        public int Add(int i, int j)
        {
            Console.WriteLine("Add() running on thread {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(1000);
            return (i + j);
        }
        public void Callback2(IAsyncResult asyc)
        {
            Console.WriteLine("second thread callback");
        }
        public void Callback(IAsyncResult asyc)
        {
            Console.WriteLine("first thread callback");
        }
    }
}
