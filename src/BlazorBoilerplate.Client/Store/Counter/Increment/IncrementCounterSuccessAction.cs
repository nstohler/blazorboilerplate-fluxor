using System;
using System.Text.Json.Serialization;

namespace BlazorBoilerplate.Client.Store.Counter.Increment
{
    public class IncrementCounterSuccessAction
    {
        public IncrementCounterSuccessAction(int serverCount, Action successAction)
        {
            ServerCount = serverCount;
            SuccessAction = successAction;
        }

        public int ServerCount { get; private set; }

        [JsonIgnore]
        public Action SuccessAction { get; }
    }
}
