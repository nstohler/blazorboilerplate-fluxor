using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.Counter
{
    public class IncrementCounterSuccessActionReducer : Reducer<CounterState, IncrementCounterSuccessAction>
    {
        public override CounterState Reduce(CounterState state, IncrementCounterSuccessAction action)
        {
            return new CounterState(false, true, null, action.ServerCount);
        }
    }
}
