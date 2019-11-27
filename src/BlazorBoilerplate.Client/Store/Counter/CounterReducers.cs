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
            var newState = (CounterState)FastDeepCloner.DeepCloner.Clone(state);

            // only changes need to be done here now
            newState.IsLoading = true;
            newState.IsLoaded = false;
            newState.ErrorMessage = null;
            
            return newState;
            //return new CounterState(
            //    true,
            //    false,
            //    null,
            //    state.CurrentCount
            //);
        }

        [ReducerMethod]
        public ICounterState Reduce(ICounterState state, IncrementCounterResultAction action)
        {
            var newState = (CounterState)FastDeepCloner.DeepCloner.Clone(state);

            // only changes need to be done here now
            newState.IsLoading    = false;
            newState.IsLoaded     = action.IsSuccess;
            newState.ErrorMessage = action.ErrorMessage;
            newState.CurrentCount = action.IsSuccess ? action.Count : 0;

            return newState;

            //return new CounterState(false, false, action.ErrorMessage, -1);
        }

        //[ReducerMethod]
        //public ICounterState Reduce(ICounterState state, IncrementCounterSuccessAction action)
        //{
        //    //return new CounterState(false, true, null, action.ServerCount);

        //    Console.WriteLine("CounterReducer IncrementCounterSuccessAction");
         
        //    var newState = (CounterState)FastDeepCloner.DeepCloner.Clone(state);

        //    // only changes need to be done here now
        //    newState.IsLoading    = false;
        //    newState.IsLoaded     = true;
        //    newState.ErrorMessage = null;
        //    newState.CurrentCount = action.ServerCount;

        //    return newState;
        //}

    }
}
