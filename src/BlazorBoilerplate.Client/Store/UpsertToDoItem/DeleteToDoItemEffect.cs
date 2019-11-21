using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.UpsertToDoItem
{
    public class DeleteToDoItemEffect : Effect<DeleteToDoItemAction>
    {
        private readonly HttpClient _httpClient;

        public DeleteToDoItemEffect(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        protected override async Task HandleAsync(DeleteToDoItemAction action, IDispatcher dispatcher)
        {
            try
            {
                var response = await _httpClient.DeleteAsync("api/todo/" + action.TodoDto.Id);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    dispatcher.Dispatch(new DeleteToDoItemSuccessAction(action.TodoDto));
                }
                else
                {
                    dispatcher.Dispatch(new DeleteToDoItemFailedAction("Delete failed : " + response.StatusCode));
                }
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new DeleteToDoItemFailedAction(e.Message));
            }
        }
    }
}