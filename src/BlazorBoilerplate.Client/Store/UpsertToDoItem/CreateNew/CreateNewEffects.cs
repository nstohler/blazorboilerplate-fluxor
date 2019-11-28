using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazor.Fluxor;
using BlazorBoilerplate.Shared.Dto;
using Microsoft.AspNetCore.Components;

namespace BlazorBoilerplate.Client.Store.UpsertToDoItem.CreateNew
{
    public class CreateNewEffects
    {
        private readonly HttpClient _httpClient;

        public CreateNewEffects(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [EffectMethod]
        public async Task HandleAsync(CreateNewToDoItemAction action, IDispatcher dispatcher)
        {
            try
            {
                ApiResponseDto apiResponse = await _httpClient.PostJsonAsync<ApiResponseDto>("api/todo", action.AddTodo);

                if (apiResponse.StatusCode == 200)
                {
                    var todo = Newtonsoft.Json.JsonConvert.DeserializeObject<TodoDto>(apiResponse.Result.ToString());

                    dispatcher.Dispatch(new CreateNewToDoItemResultAction(todo, true, null)); // catch, add to collection
                }
                else
                {
                    dispatcher.Dispatch(new CreateNewToDoItemResultAction(null, false, "CreateNewToDo failed : " + apiResponse.StatusCode));
                }
            }
            catch (Exception ex)
            {
                dispatcher.Dispatch(new CreateNewToDoItemResultAction(null, false, ex.Message));
            }
        }
    }
}
