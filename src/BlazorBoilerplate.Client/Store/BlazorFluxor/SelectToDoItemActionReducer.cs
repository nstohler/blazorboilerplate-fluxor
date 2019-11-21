using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.BlazorFluxor
{
    public class SelectToDoItemActionReducer : Reducer<BlazorFluxorState, SelectToDoItemAction>
    {
        public override BlazorFluxorState Reduce(BlazorFluxorState state, SelectToDoItemAction action)
        {
            return new BlazorFluxorState(
                action.ToDoId,
                null
            );
        }
    }
}