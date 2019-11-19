using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Client.Store.Counter
{
    public class CounterState
    {
        public int CurrentCount { get; private set; }

        public CounterState(int currentCount)
        {
            CurrentCount = currentCount;
        }
    }
}
