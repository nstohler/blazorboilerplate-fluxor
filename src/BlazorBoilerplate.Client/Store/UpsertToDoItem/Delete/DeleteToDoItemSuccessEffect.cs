using System.Threading.Tasks;
using Blazor.Fluxor;
using BlazorBoilerplate.Client.Store.BlazorFluxor;
using BlazorBoilerplate.Client.Store.BlazorFluxor.DetailById;
using BlazorBoilerplate.Client.Store.BlazorFluxor.EditById;
using BlazorBoilerplate.Client.Store.FetchToDo;
using BlazorBoilerplate.Client.Store.FetchToDo.SideEffects;

namespace BlazorBoilerplate.Client.Store.UpsertToDoItem.Delete
{
    public class DeleteToDoItemSuccessEffect : Effect<DeleteToDoItemSuccessAction>
    {
        protected override Task HandleAsync(DeleteToDoItemSuccessAction action, IDispatcher dispatcher)
        {
            dispatcher.Dispatch(new RemoveToDoItemAction(action.TodoDto));

            // clear selections
            // TODO: could also clear those using an Effect in BlazorFluxor store
            dispatcher.Dispatch(new DetailByIdToDoItemAction(null));
            dispatcher.Dispatch(new EditByIdToDoItemAction(null));

            return Task.CompletedTask;
        }
    }
}
