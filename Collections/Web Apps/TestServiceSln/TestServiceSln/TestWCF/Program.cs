using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestWCF.RealServiceReference;
using System.Diagnostics;
using System.Threading;
namespace TestWCF
{
    class Program
    {
        public static void Main(string[] args)
        {
            //ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            //string str = client.GetData(23);
            //Console.Write(str);
            //MyService.Service1Client objSer = new MyService.Service1Client("MyWsHttpContract");
            //Console.Write(objSer.GetData(100));


            //string gg = Console.ReadLine();

            //MyService.Service1Client objSer2 = new MyService.Service1Client("basicbinding");
            //Console.Write(objSer.GetData(100));

            RealServiceReference.TestServiceClient objNew = new TestServiceClient("WSHttpBinding_ITestService");
            //AsyncCallback async =
            ProgressBar pr = new ProgressBar();
            Console.WriteLine(objNew.DoWork());

            //IAsyncResult result = objNew.BeginDoWork(null, null);
            //if (!result.AsyncWaitHandle.WaitOne(2000))
            //{

            //    MyProgressBarDelegate objDel = new MyProgressBarDelegate(pr.MyProgressBar);
            //    IAsyncResult result2 = objDel.BeginInvoke(null, null);
            //    objDel.EndInvoke(result2);
                
            //    string display = objNew.EndDoWork(result);
            //    Console.WriteLine(display);

            //    result.AsyncWaitHandle.Close();

            //}

            TestWCF.TestServiceReference.TestServiceClient objClient = new TestServiceReference.TestServiceClient();
            Console.WriteLine(objClient.DoWork());

            string gg2 = Console.ReadLine();

        }
    }
}
