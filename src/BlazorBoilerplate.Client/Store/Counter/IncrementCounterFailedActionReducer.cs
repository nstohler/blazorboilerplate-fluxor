using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.Counter
{
    public class IncrementCounterFailedActionReducer : Reducer<CounterState, IncrementCounterFailedAction>
    {
        public override CounterState Reduce(CounterState state, IncrementCounterFailedAction action)
        {
            return new CounterState(false, false, action.ErrorMessage, -1);
        }
    }
}
