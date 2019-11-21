using System.Collections.Immutable;
using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.FetchToDo
{
    public class GetToDoItemsSuccessActionReducer : Reducer<FetchToDoItemsState, GetToDoItemsSuccessAction>
    {
        public override FetchToDoItemsState Reduce(FetchToDoItemsState state, GetToDoItemsSuccessAction action)
        {
            return new FetchToDoItemsState(
                false, 
                null, 
                action.ToToItems?.ToImmutableList()
            );
        }
    }
}