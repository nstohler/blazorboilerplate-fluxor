using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.UpsertToDoItem.Update
{
    public class UpsertToDoItemActionReducer : Reducer<UpsertToDoItemState, UpsertToDoItemAction>
    {
        public override UpsertToDoItemState Reduce(UpsertToDoItemState state, UpsertToDoItemAction itemAction)
        {
            return new UpsertToDoItemState(true, null, null);
        }
    }
}
