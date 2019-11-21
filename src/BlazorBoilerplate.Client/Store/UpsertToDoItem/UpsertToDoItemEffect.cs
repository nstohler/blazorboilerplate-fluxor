using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;
using BlazorBoilerplate.Client.Store.FetchToDo;
using BlazorBoilerplate.Client.Store.FetchToDo.UpsertToDoItem;
using BlazorBoilerplate.Shared.Dto;
using MatBlazor;
using Microsoft.AspNetCore.Components;

namespace BlazorBoilerplate.Client.Store.UpsertToDoItem
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
