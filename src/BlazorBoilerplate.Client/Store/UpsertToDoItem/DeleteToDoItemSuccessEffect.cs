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
