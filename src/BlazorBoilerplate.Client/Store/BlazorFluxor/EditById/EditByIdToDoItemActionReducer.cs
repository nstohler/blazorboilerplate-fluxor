using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.BlazorFluxor.EditById
{
    public class EditByIdToDoItemActionReducer : Reducer<IBlazorFluxorState, EditByIdToDoItemAction>
    {
        public override IBlazorFluxorState Reduce(IBlazorFluxorState state, EditByIdToDoItemAction action)
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