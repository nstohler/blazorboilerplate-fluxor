using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.UpsertToDoItem
{
    public class DeleteToDoItemFailedActionReducer: Reducer<UpsertToDoItemState, DeleteToDoItemFailedAction>
    {
        public override UpsertToDoItemState Reduce(UpsertToDoItemState state, DeleteToDoItemFailedAction action)
        {
            return new UpsertToDoItemState(
                false, 
                state.TodoDto, 
                action.ErrorMessage
            );
        }
    }
}