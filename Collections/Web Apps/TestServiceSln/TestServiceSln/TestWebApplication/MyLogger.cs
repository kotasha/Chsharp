using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace TestWebApplication
{
    public class MyLogger : ILogger
    {
        public void Initialize(IEventSource eventSource)
        {
            throw new NotImplementedException();
        }

        public string Parameters
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Shutdown()
        {
            throw new NotImplementedException();
        }

        public LoggerVerbosity Verbosity
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}