using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.FetchToDo.Get
{
    public class GetToDoItemsFailedActionReducer : Reducer<FetchToDoItemsState, GetToDoItemsFailedAction>
    {
        public override FetchToDoItemsState Reduce(FetchToDoItemsState state, GetToDoItemsFailedAction action)
        {
            return new FetchToDoItemsState(
                false,
                action.ErrorMessage,
                null
            );
        }
    }
}