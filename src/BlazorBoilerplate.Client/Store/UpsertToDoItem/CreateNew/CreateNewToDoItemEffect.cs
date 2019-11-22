using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;
using BlazorBoilerplate.Shared.Dto;
using MatBlazor;
using Microsoft.AspNetCore.Components;

namespace BlazorBoilerplate.Client.Store.UpsertToDoItem.CreateNew
{
    public class CreateNewToDoItemEffect : Effect<CreateNewToDoItemAction>
    {
        private readonly HttpClient _httpClient;

        public CreateNewToDoItemEffect(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        protected override async Task HandleAsync(CreateNewToDoItemAction action, IDispatcher dispatcher)
        {
            try
            {
                ApiResponseDto apiResponse = await _httpClient.PostJsonAsync<ApiResponseDto>("api/todo", action.AddTodo);

                if (apiResponse.StatusCode == 200)
                {
                    var todo = Newtonsoft.Json.JsonConvert.DeserializeObject<TodoDto>(apiResponse.Result.ToString());
                    dispatcher.Dispatch(new CreateNewToDoItemSuccessAction(todo));  // catch, add to collection
                }
                else
                {
                    dispatcher.Dispatch(new CreateNewToDoItemFailedAction("Delete failed : " + apiResponse.StatusCode));
                }
            }
            catch (Exception ex)
            {
                dispatcher.Dispatch(new CreateNewToDoItemFailedAction(ex.Message));
            }
        }
    }
}
