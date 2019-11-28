using System.Linq;
using System.Threading.Tasks;
using Blazor.Fluxor;
using BlazorBoilerplate.Client.Store.BlazorFluxor.DetailByRef;
using BlazorBoilerplate.Client.Store.FetchToDo;

namespace BlazorBoilerplate.Client.Store.BlazorFluxor.DetailById
{
    public class DetailByIdToDoItemEffect : Effect<DetailByIdToDoItemAction>
    {
        private readonly IState<IFetchToDoItemsState> _fetchToDoItemsState;

        public DetailByIdToDoItemEffect(IState<IFetchToDoItemsState> fetchToDoItemsState)
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
