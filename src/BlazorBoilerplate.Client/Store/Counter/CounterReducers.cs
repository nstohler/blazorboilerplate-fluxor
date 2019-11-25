using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;
using BlazorBoilerplate.Client.Store.Counter.Increment;

namespace BlazorBoilerplate.Client.Store.Counter
{
    public class CounterReducers 
    {
        // injection possible...

        [ReducerMethod]
        public ICounterState Reduce(ICounterState state, IncrementCounterAction action)
        {
            return new CounterState(
                true,
                false,
                null,
                state.CurrentCount
            );
        }

        [ReducerMethod]
        public ICounterState Reduce(ICounterState state, IncrementCounterFailedAction action)
        {
            return new CounterState(false, false, action.ErrorMessage, -1);
        }

        [ReducerMethod]
        public ICounterState Reduce(ICounterState state, IncrementCounterSuccessAction action)
        {
            return new CounterState(false, true, null, action.ServerCount);
        }

    }
}
