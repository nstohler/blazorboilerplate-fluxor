using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.BlazorFluxor.DetailByRef
{
    public class DetailByRefToDoItemReducer : Reducer<BlazorFluxorState, DetailByRefToDoItemAction>
    {
        public override BlazorFluxorState Reduce(BlazorFluxorState state, DetailByRefToDoItemAction action)
        {
            return new BlazorFluxorState(
                state.DetailToDoId, 
                action.ToDoItem, 
                state.EditToDoId,
                state.EditToDoDto
            );
        }
    }
}