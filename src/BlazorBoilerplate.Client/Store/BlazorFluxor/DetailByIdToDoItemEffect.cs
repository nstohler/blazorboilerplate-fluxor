using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;
using BlazorBoilerplate.Client.Store.FetchToDo;

namespace BlazorBoilerplate.Client.Store.BlazorFluxor
{
    public class DetailByIdToDoItemEffect : Effect<DetailByIdToDoItemAction>
    {
        private readonly IState<FetchToDoItemsState> _fetchToDoItemsState;

        public DetailByIdToDoItemEffect(IState<FetchToDoItemsState> fetchToDoItemsState)
        {
            _fetchToDoItemsState = fetchToDoItemsState;
        }

        protected override Task HandleAsync(DetailByIdToDoItemAction action, IDispatcher dispatcher)
        {
            // check if loaded (possible)?
            var item = _fetchToDoItemsState.Value.ToDoItems.SingleOrDefault(x => x.Id == action.ToDoItemId);

            dispatcher.Dispatch(new DetailByRefToDoItemAction(item));

            return Task.CompletedTask;
        }
    }
}
