using System.Threading.Tasks;
using Blazor.Fluxor;
using BlazorBoilerplate.Client.Store.BlazorFluxor;
using BlazorBoilerplate.Client.Store.BlazorFluxor.EditById;
using BlazorBoilerplate.Client.Store.BlazorFluxor.RefreshDetail;
using BlazorBoilerplate.Client.Store.FetchToDo;
using BlazorBoilerplate.Client.Store.FetchToDo.SideEffects;
using MatBlazor;

namespace BlazorBoilerplate.Client.Store.UpsertToDoItem.Update
{
    public class UpsertToDoItemSuccessEffect  : Effect<UpsertToDoItemSuccessAction>
    {
        private readonly IMatToaster _matToaster;

        public UpsertToDoItemSuccessEffect(IMatToaster matToaster)
        {
            _matToaster = matToaster;
        }

        protected override Task HandleAsync(UpsertToDoItemSuccessAction action, IDispatcher dispatcher)
        {
            // clear selection:
            dispatcher.Dispatch(new EditByIdToDoItemAction(null));
            // dispatcher.Dispatch(new DetailByIdToDoItemAction(null));

            // reload todo items
            //dispatcher.Dispatch(new GetToDoItemsAction());
            dispatcher.Dispatch(new UpdateToDoItemAction(action.TodoDto));

            // special: set as active detail view item
            // dispatcher.Dispatch(new DetailByIdToDoItemAction(action.TodoDto.Id));

            // TODO: refresh active detail item (if it was set before!)
            dispatcher.Dispatch(new RefreshDetailToDoItemAction(action.TodoDto.Id));

            _matToaster.Add("Update Success", MatToastType.Success, "Todo item updated");

            return Task.CompletedTask;
        }
    }
}
