using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;
using BlazorBoilerplate.Client.Store.Extensions;
using BlazorBoilerplate.Shared.Dto;
using Microsoft.AspNetCore.Components;

namespace BlazorBoilerplate.Client.Store.FetchToDo.Get
{
    public class GetToDoItemsEffects
    {
        private readonly HttpClient _httpClient;

        public GetToDoItemsEffects(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [EffectMethod]
        public async Task HandleAsync(GetToDoItemsAction action, IDispatcher dispatcher)
        {
            try
            {
                ApiResponseDto apiResponse = await _httpClient.GetJsonAsync<ApiResponseDto>("api/todo");

                Console.WriteLine($"GetToDoItemsEffects:GetToDoItemsAction {apiResponse.StatusCode}");

                if (apiResponse.StatusCode == (int)HttpStatusCode.OK)
                {
                    Console.WriteLine($"GetToDoItemsEffects:GetToDoItemsAction success");
                    var todos = Newtonsoft.Json.JsonConvert.DeserializeObject<TodoDto[]>(apiResponse.Result.ToString()).ToList<TodoDto>();
                    dispatcher.Dispatch(new GetToDoItemsResultAction(action.NotificationAction, todos, true, null));
                }
                else
                {
                    Console.WriteLine($"GetToDoItemsEffects:GetToDoItemsAction failed 1");
                    dispatcher.Dispatch(new GetToDoItemsResultAction(action.NotificationAction, null, true, $"{apiResponse.Message}: {apiResponse.StatusCode}"));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"GetToDoItemsEffects:GetToDoItemsAction failed ex {e.Message}");
                dispatcher.Dispatch(new GetToDoItemsResultAction(action.NotificationAction, null, false, e.Message));
            }
        }

        [EffectMethod]
        public Task HandleAsync(GetToDoItemsResultAction action, IDispatcher dispatcher)
        {
            Console.WriteLine($"GetToDoItemsResultAction effect / start callback");

            action.ExecuteNotifyComponent();

            return Task.CompletedTask;
        }
    }
}
