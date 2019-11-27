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
            //var newState = (CounterState) FastDeepCloner.DeepCloner.Clone(state);
            var newState = CounterState.CreateNew();

            newState.IsLoading    = true;

            return newState;
        }

        [ReducerMethod]
        public ICounterState Reduce(ICounterState state, IncrementCounterResultAction action)
        {
            //var newState = (CounterState) FastDeepCloner.DeepCloner.Clone(state);
            var newState = CounterState.CreateNew();

            // handle success/failed 
            if (action.IsSuccess)
            {
                newState.IsLoaded                   = true;
                newState.CurrentCount               = action.Count;
                newState.LastSuccessCounterPostTime = DateTime.UtcNow;
            }
            else
            {
                newState.ErrorMessage = action.ErrorMessage;
            }

            return newState;
        }
    }
}