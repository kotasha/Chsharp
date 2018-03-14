using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBEntries
{
    class SampleClass : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
    class Example
    {
        public Example()
        {
            using (SampleClass obj = new SampleClass())
            {
            }
        }
    }
}
