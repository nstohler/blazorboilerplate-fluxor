using Blazor.Fluxor;
using BlazorBoilerplate.Client.Store.UpsertToDoItem;

namespace BlazorBoilerplate.Client.Store.FetchToDo.UpsertToDoItem
{
    public class UpsertToDoItemActionReducer : Reducer<UpsertToDoItemState, UpsertToDoItemAction>
    {
        public override UpsertToDoItemState Reduce(UpsertToDoItemState state, UpsertToDoItemAction itemAction)
        {
            return new UpsertToDoItemState(true, null, null);
        }
    }
}
