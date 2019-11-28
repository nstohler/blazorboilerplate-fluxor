using System;
using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.Counter.Increment
{
    public class IncrementCounterReducers
    {
        [ReducerMethod]
        public ICounterState Reduce(ICounterState state, IncrementCounterAction action)
        {
            var newState = CounterState.CreateNew();

            newState.IsLoading    = true;

            return newState;
        }

        [ReducerMethod]
        public ICounterState Reduce(ICounterState state, IncrementCounterResultAction action)
        {
            //var newState = (CounterState) FastDeepCloner.DeepCloner.Clone(state); // clone

            var newState = CounterState.CreateNew(); // create default

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