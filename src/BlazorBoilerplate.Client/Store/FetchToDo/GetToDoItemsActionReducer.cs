using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.FetchToDo
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