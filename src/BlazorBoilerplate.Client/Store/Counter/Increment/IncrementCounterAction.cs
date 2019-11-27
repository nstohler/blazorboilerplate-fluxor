using System;
using System.Text.Json.Serialization; // NOT Newtonsoft.Json!

namespace BlazorBoilerplate.Client.Store.Counter.Increment
{
    public class IncrementCounterAction
    {
        public IncrementCounterAction(int prevCount, Action successAction = null
        )
        {
            SuccessAction = successAction;
            PrevCount     = prevCount;
        }

        public int PrevCount { get; private set; }

        [JsonIgnore] // for ReduxDevToolsMiddleware to not serialize this
        public Action SuccessAction { get; private set; }
    }
}