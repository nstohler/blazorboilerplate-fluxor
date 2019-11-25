using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.UpsertToDoItem.Update
{
    public class UpsertToDoItemSuccessActionReducer : Reducer<UpsertToDoItemState, UpsertToDoItemSuccessAction>
    {
        public override UpsertToDoItemState Reduce(UpsertToDoItemState state, UpsertToDoItemSuccessAction action)
        {
            return new UpsertToDoItemState(false, action.TodoDto, null);
        }
    }
}
