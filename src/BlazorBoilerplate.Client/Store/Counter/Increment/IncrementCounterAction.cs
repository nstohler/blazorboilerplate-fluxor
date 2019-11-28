using System;
using System.Text.Json.Serialization; // NOT Newtonsoft.Json!

namespace BlazorBoilerplate.Client.Store.Counter.Increment
{
    public class IncrementCounterAction
    {
        public IncrementCounterAction(int prevCount)
        {
            PrevCount     = prevCount;
        }

        public int PrevCount { get; private set; }
    }
}