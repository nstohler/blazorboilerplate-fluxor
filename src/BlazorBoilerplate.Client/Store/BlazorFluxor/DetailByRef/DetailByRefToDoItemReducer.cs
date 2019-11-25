using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.BlazorFluxor.DetailByRef
{
    public class DetailByRefToDoItemReducer : Reducer<IBlazorFluxorState, DetailByRefToDoItemAction>
    {
        public override IBlazorFluxorState Reduce(IBlazorFluxorState state, DetailByRefToDoItemAction action)
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