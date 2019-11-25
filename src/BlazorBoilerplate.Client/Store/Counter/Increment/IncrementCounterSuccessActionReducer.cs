using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.Counter.Increment
{
    public class IncrementCounterSuccessActionReducer : Reducer<CounterState, IncrementCounterSuccessAction>
    {
        public override CounterState Reduce(CounterState state, IncrementCounterSuccessAction action)
        {
            return new CounterState(false, true, null, action.ServerCount);
        }
    }
}
