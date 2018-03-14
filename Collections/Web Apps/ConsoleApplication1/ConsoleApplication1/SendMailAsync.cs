using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplication1
{
    public class SendMailAsync
    {
        public delegate void SendMail(string message);
        public delegate int Mail(int i);
        //public event SendMail SendMailEvent;

        private Details _myDetails;
        public SendMailAsync()
        {
            _myDetails = new Details();
        }

        public void Display()
        {
            try
            {
                SendMail mail = new SendMail(_myDetails.SendEmailtoUsers);
                //var gb = new {Name="sd",Address = "dfdf"};
                List<string> str = new List<string>();
                str.OrderBy(sq => sq.Contains("s"));
                //IAsyncResult asyncoll;

                //for (int i = 0; i < 100; i++)
                //{
                //    asyncoll = mail.BeginInvoke(i.ToString(), null, null);
                //    mail.EndInvoke(asyncoll);
                //}
                IAsyncResult asyc = mail.BeginInvoke("displaying message", null, null);
                
                //if (!asyc.AsyncWaitHandle.WaitOne(500))
                {
                    Thread[] threads = new Thread[10];
                    ThreadStart start;
                    for (int i = 0; i < 10; i++)
                    {
                        start = new ThreadStart(() => _myDetails.SendEmailtoUsers(i.ToString()));
                        //start = new ThreadStart(() => _myDetails.intsend(i));
                        threads[i] = new Thread(start);
                        threads[i].Start();
                    }

                mail.EndInvoke(asyc);
                }

            }
            catch (Exception objEx)
            {
                Console.WriteLine("Exception occured " + objEx.Message);
            }

        }
    }
    public class Details
    {
        public Details()
        {
        }
        public int intsend(int i)
        {
            return i;
        }
        public void SendEmailtoUsers(string msg)
        {
            //lock (this)
            {
                for (int j = 0; j < 5; j++)
                {
                    Thread.Sleep(500);
                    Console.WriteLine("mail msg " + msg + " " + j.ToString());
                }
            }
        }
    }
}
