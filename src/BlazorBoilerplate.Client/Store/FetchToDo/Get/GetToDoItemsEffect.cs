using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Blazor.Fluxor;
using BlazorBoilerplate.Shared.Dto;
using Microsoft.AspNetCore.Components;

namespace BlazorBoilerplate.Client.Store.FetchToDo.Get
{
    public class GetToDoItemsEffect : Effect<GetToDoItemsAction>
    {
        private readonly HttpClient _httpClient;

        public GetToDoItemsEffect(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        protected override async Task HandleAsync(GetToDoItemsAction action, IDispatcher dispatcher)
        {
            try
            {
                ApiResponseDto apiResponse = await _httpClient.GetJsonAsync<ApiResponseDto>("api/todo");

                if (apiResponse.StatusCode == 200)
                {
                    var todos = Newtonsoft.Json.JsonConvert.DeserializeObject<TodoDto[]>(apiResponse.Result.ToString()).ToList<TodoDto>();
                    dispatcher.Dispatch(new GetToDoItemsSuccessAction(todos));
                }
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new GetToDoItemsFailedAction(e.Message));
            }
        }
    }
}