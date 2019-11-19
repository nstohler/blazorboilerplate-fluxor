using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.Counter
{
    public class IncrementCounterReducer : Reducer<CounterState, IncrementCounterAction>
    {
        public override CounterState Reduce(CounterState state, IncrementCounterAction action)
        {
            return new CounterState(
                true,
                false, 
                null,
                state.CurrentCount
                //-1
                //state.CurrentCount + 1
                );
        }
    }
}