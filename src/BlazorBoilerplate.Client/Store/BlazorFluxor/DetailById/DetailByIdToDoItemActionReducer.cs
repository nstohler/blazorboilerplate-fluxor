using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.BlazorFluxor.DetailById
{
    public class DetailByIdToDoItemActionReducer : Reducer<IBlazorFluxorState, DetailByIdToDoItemAction>
    {
        public override IBlazorFluxorState Reduce(IBlazorFluxorState state, DetailByIdToDoItemAction action)
        {
            return new BlazorFluxorState(action.ToDoItemId, 
                null, 
                state.EditToDoId,
                state.EditToDoDto
                );
        }
    }
}
