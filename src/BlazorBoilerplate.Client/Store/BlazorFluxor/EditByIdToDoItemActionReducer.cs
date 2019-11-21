using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.BlazorFluxor
{
    public class EditByIdToDoItemActionReducer : Reducer<BlazorFluxorState, EditByIdToDoItemAction>
    {
        public override BlazorFluxorState Reduce(BlazorFluxorState state, EditByIdToDoItemAction action)
        {
            return new BlazorFluxorState(
                state.DetailToDoId, 
                state.DetailToDoDto,
                action.ToDoId,
                null
            );
        }
    }
}