using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Client.Store.Counter
{
    public class IncrementCounterAction
    {
        public IncrementCounterAction(int prevCount)
        {
            PrevCount = prevCount;
        }
        // empty

        public int PrevCount { get; private set; }
    }
}
