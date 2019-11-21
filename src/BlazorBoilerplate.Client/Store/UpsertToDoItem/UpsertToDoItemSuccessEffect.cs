using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;
using BlazorBoilerplate.Client.Store.BlazorFluxor;
using BlazorBoilerplate.Client.Store.FetchToDo;

namespace BlazorBoilerplate.Client.Store.UpsertToDoItem
{
    public class UpsertToDoItemSuccessEffect  : Effect<UpsertToDoItemSuccessAction>
    {
        protected override Task HandleAsync(UpsertToDoItemSuccessAction action, IDispatcher dispatcher)
        {
            // clear selection:
            dispatcher.Dispatch(new SelectToDoItemAction(null));

            // reload todo items
            //dispatcher.Dispatch(new GetToDoItemsAction());
            dispatcher.Dispatch(new UpdateToDoItemAction(action.TodoDto));

            return Task.CompletedTask;
        }
    }
}
