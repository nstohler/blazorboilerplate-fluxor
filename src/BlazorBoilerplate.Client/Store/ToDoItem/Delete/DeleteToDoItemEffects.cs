using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazor.Fluxor;
using BlazorBoilerplate.Client.Store.BlazorFluxor.DetailById;
using BlazorBoilerplate.Client.Store.BlazorFluxor.EditById;
using BlazorBoilerplate.Client.Store.FetchToDo.SideEffects;

namespace BlazorBoilerplate.Client.Store.ToDoItem.Delete
{
    public class DeleteToDoItemEffects
    {
        private readonly HttpClient _httpClient;

        public DeleteToDoItemEffects(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [EffectMethod]
        public async Task HandleAsync(DeleteToDoItemAction action, IDispatcher dispatcher)
        {
            try
            {
                var response = await _httpClient.DeleteAsync("api/todo/" + action.TodoDto.Id);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    dispatcher.Dispatch(new DeleteToDoItemResultAction(action.TodoDto, true, null));
                }
                else
                {
                    dispatcher.Dispatch(new DeleteToDoItemResultAction(null, false,
                        "Delete failed : " + response.StatusCode));
                }
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new DeleteToDoItemResultAction(null, false, e.Message));
            }
        }

        [EffectMethod]
        public Task HandleAsync(DeleteToDoItemResultAction action, IDispatcher dispatcher)
        {
            if (!action.IsSuccess)
            {
                return Task.CompletedTask;
            }

            dispatcher.Dispatch(new RemoveToDoItemAction(action.TodoDto));

            // clear selections
            // TODO: could also clear those using an Effect in BlazorFluxor store
            dispatcher.Dispatch(new DetailByIdToDoItemAction(null));
            dispatcher.Dispatch(new EditByIdToDoItemAction(null));

            return Task.CompletedTask;
        }
    }
}