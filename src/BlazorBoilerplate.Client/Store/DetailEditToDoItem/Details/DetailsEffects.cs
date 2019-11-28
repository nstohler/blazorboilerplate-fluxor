using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;
using BlazorBoilerplate.Client.Store.FetchToDo;

namespace BlazorBoilerplate.Client.Store.DetailEditToDoItem.Details
{
    public class DetailsEffects
    {
        private readonly IState<IFetchToDoItemsState> _fetchToDoItemsState;

        public DetailsEffects(IState<IFetchToDoItemsState> fetchToDoItemsState)
        {
            _fetchToDoItemsState = fetchToDoItemsState;
        }

        [EffectMethod]
        public Task HandleAsync(DetailByIdToDoItemAction action, IDispatcher dispatcher)
        {
            // check if loaded (possible)?
            var item = _fetchToDoItemsState.Value.ToDoItems.SingleOrDefault(x => x.Id == action.ToDoItemId);

            dispatcher.Dispatch(new DetailByRefToDoItemAction(item));

            return Task.CompletedTask;
        }
    }
}
