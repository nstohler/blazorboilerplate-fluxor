using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazor.Fluxor;
using BlazorBoilerplate.Client.Store.DetailEditToDoItem.Details;
using BlazorBoilerplate.Client.Store.DetailEditToDoItem.Edit;
using BlazorBoilerplate.Client.Store.FetchToDo.ToDoItemSideEffects;
using BlazorBoilerplate.Client.Store.Services;

namespace BlazorBoilerplate.Client.Store.ToDoItem.Delete
{
    public class DeleteToDoItemEffects
    {
        private readonly HttpClient               _httpClient;
        private readonly ComponentNotifierService _componentNotifierService;

        public DeleteToDoItemEffects(HttpClient httpClient, ComponentNotifierService componentNotifierService)
        {
            _httpClient               = httpClient;
            _componentNotifierService = componentNotifierService;
        }

        [EffectMethod]
        public async Task HandleAsync(DeleteToDoItemAction action, IDispatcher dispatcher)
        {
            try
            {
                var response = await _httpClient.DeleteAsync("api/todo/" + action.TodoDto.Id);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    dispatcher.Dispatch(new DeleteToDoItemResultAction(action.NotificationAction, action.TodoDto, true,
                        null));
                }
                else
                {
                    dispatcher.Dispatch(new DeleteToDoItemResultAction(action.NotificationAction, null, false,
                        "Delete failed : " + response.StatusCode));
                }
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new DeleteToDoItemResultAction(action.NotificationAction, null, false, e.Message));
            }
        }

        [EffectMethod]
        public Task HandleAsync(DeleteToDoItemResultAction action, IDispatcher dispatcher)
        {
            if (!action.IsSuccess)
            {
                return Task.CompletedTask;
            }

            // let FetchToDoState remove the item from its collection:
            dispatcher.Dispatch(new RemoveToDoItemAction(action.TodoDto));

            // clear selections
            // TODO: could also clear those using an Effect in BlazorFluxor store
            dispatcher.Dispatch(new DetailByIdToDoItemAction(null));
            dispatcher.Dispatch(new EditByIdToDoItemAction(null));

            //action.ExecuteNotifyComponent();
            _componentNotifierService.ForwardAction(action);

            return Task.CompletedTask;
        }
    }
}