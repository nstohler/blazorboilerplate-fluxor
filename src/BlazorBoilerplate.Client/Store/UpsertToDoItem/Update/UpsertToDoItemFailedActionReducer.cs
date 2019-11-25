using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.UpsertToDoItem.Update
{
    public class UpsertToDoItemFailedActionReducer : Reducer<UpsertToDoItemState, UpsertToDoItemFailedAction>
    {
        public override UpsertToDoItemState Reduce(UpsertToDoItemState state, UpsertToDoItemFailedAction action)
        {
            return new UpsertToDoItemState(false, null, action.ErrorMessage);
        }
    }
}