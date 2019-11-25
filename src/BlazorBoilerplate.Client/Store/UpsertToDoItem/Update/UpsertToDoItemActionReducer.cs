using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.UpsertToDoItem.Update
{
    public class UpsertToDoItemActionReducer : Reducer<IUpsertToDoItemState, UpsertToDoItemAction>
    {
        public override IUpsertToDoItemState Reduce(IUpsertToDoItemState state, UpsertToDoItemAction itemAction)
        {
            return new UpsertToDoItemState(true, null, null);
        }
    }
}
