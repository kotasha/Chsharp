using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace abstractSample
{
    public class MultipleInheritence : Ilogger
    {
        public void Log()
        {
            throw new NotImplementedException();
        }

        public void Display()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
    interface Ilogger : ISecondInterface
    {
        void Log();
    }
    interface ISecondInterface : IDisposable
    {
        void Display();
    }
}
