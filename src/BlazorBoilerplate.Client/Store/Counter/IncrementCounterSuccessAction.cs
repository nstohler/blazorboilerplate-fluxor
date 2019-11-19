using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Client.Store.Counter
{
    public class IncrementCounterSuccessAction
    {
        public IncrementCounterSuccessAction(int serverCount)
        {
            ServerCount = serverCount;
        }

        public int ServerCount { get; private set; }
    }
}
