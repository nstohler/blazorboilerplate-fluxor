using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazor.Fluxor;
using BlazorBoilerplate.Shared.Dto;
using Microsoft.AspNetCore.Components;

namespace BlazorBoilerplate.Client.Store.UpsertToDoItem.Update
{
    public class UpsertToDoItemEffect : Effect<UpsertToDoItemAction>
    {
        private readonly HttpClient _httpClient;

        public UpsertToDoItemEffect(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        protected override async Task HandleAsync(UpsertToDoItemAction action, IDispatcher dispatcher)
        {
            try
            {
                ApiResponseDto apiResponse = await _httpClient.PutJsonAsync<ApiResponseDto>("api/todo", action.TodoDto);
                await Task.Delay(2000); // simulate long roundtrip time

                if (!apiResponse.IsError)
                {
                    dispatcher.Dispatch(new UpsertToDoItemSuccessAction(action.TodoDto));
                }
                else
                {
                    dispatcher.Dispatch(new UpsertToDoItemFailedAction(apiResponse.Message + " : " + apiResponse.StatusCode));
                }
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new UpsertToDoItemFailedAction(e.Message));
            }
        }
    }
}
