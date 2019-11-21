using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.UpsertToDoItem
{
    public class DeleteToDoItemSuccessActionReducer : Reducer<UpsertToDoItemState, DeleteToDoItemSuccessAction>
    {
        public override UpsertToDoItemState Reduce(UpsertToDoItemState state, DeleteToDoItemSuccessAction action)
        {
            return new UpsertToDoItemState(false, null, null);
        }
    }
}