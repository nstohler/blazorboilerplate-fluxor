using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazor.Fluxor;
using BlazorBoilerplate.Client.Store.FetchToDo.ToDoItemSideEffects;
using BlazorBoilerplate.Client.Store.Services;
using BlazorBoilerplate.Shared.Dto;
using Microsoft.AspNetCore.Components;

namespace BlazorBoilerplate.Client.Store.ToDoItem.CreateNew
{
    public class CreateNewEffects
    {
        private readonly HttpClient               _httpClient;
        private readonly ComponentNotifierService _componentNotifierService;

        public CreateNewEffects(HttpClient httpClient, ComponentNotifierService componentNotifierService)
        {
            _httpClient               = httpClient;
            _componentNotifierService = componentNotifierService;
        }

        [EffectMethod]
        public async Task HandleAsync(CreateNewToDoItemAction action, IDispatcher dispatcher)
        {
            try
            {
                ApiResponseDto apiResponse =
                    await _httpClient.PostJsonAsync<ApiResponseDto>("api/todo", action.AddTodo);

                if (apiResponse.StatusCode == 200)
                {
                    var todo = Newtonsoft.Json.JsonConvert.DeserializeObject<TodoDto>(apiResponse.Result.ToString());

                    dispatcher.Dispatch(
                        new CreateNewToDoItemResultAction(action.NotificationAction, todo, true,
                            null)); // catch, add to collection

                    // let FetchToDoState add item to its collection:
                    dispatcher.Dispatch(new AddToDoItemAction(todo));
                }
                else
                {
                    dispatcher.Dispatch(new CreateNewToDoItemResultAction(action.NotificationAction, null, false,
                        "CreateNewToDo failed : " + apiResponse.StatusCode));
                }
            }
            catch (Exception ex)
            {
                dispatcher.Dispatch(
                    new CreateNewToDoItemResultAction(action.NotificationAction, null, false, ex.Message));
            }
        }

        [EffectMethod]
        public Task HandleAsync(CreateNewToDoItemResultAction action, IDispatcher dispatcher)
        {
            //action.ExecuteNotifyComponent();
            _componentNotifierService.ForwardAction(action);

            return Task.CompletedTask;
        }
    }
}