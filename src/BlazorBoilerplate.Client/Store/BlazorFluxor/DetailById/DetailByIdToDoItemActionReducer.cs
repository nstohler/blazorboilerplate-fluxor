using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.BlazorFluxor.DetailById
{
    public class DetailByIdToDoItemActionReducer : Reducer<BlazorFluxorState, DetailByIdToDoItemAction>
    {
        public override BlazorFluxorState Reduce(BlazorFluxorState state, DetailByIdToDoItemAction action)
        {
            return new BlazorFluxorState(action.ToDoItemId, 
                null, 
                state.EditToDoId,
                state.EditToDoDto
                );
        }
    }
}
