using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.UpsertToDoItem.Delete
{
    public class DeleteToDoItemActionReducer: Reducer<UpsertToDoItemState, DeleteToDoItemAction>
    {
        public override UpsertToDoItemState Reduce(UpsertToDoItemState state, DeleteToDoItemAction action)
        {
            return new UpsertToDoItemState(
                true, 
                action.TodoDto, 
                null);
        }
    }
}
