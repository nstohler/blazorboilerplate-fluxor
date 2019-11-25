using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.FetchToDo.Get
{
    public class GetToDoItemsActionReducer : Reducer<FetchToDoItemsState, GetToDoItemsAction>
    {
        public override FetchToDoItemsState Reduce(FetchToDoItemsState state, GetToDoItemsAction action)
        {
            return new FetchToDoItemsState(
                true,
                null,
                null
            );
        }
    }
}