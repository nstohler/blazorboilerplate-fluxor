using System;
using BlazorBoilerplate.Client.Pages;
using BlazorBoilerplate.Client.Store.Counter.Report;
using System.Text.Json.Serialization;

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