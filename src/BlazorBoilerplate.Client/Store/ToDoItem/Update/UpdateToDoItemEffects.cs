using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazor.Fluxor;
using BlazorBoilerplate.Client.Store.BlazorFluxor.EditById;
using BlazorBoilerplate.Client.Store.BlazorFluxor.RefreshDetail;
using BlazorBoilerplate.Shared.Dto;
using MatBlazor;
using Microsoft.AspNetCore.Components;

namespace BlazorBoilerplate.Client.Store.ToDoItem.Update
{
    public class UpdateToDoItemEffects
    {
        private readonly HttpClient _httpClient;
        private readonly IMatToaster _matToaster;

        public UpdateToDoItemEffects(HttpClient httpClient, IMatToaster matToaster)
        {
            _httpClient = httpClient;
            _matToaster = matToaster;
        }

        [EffectMethod]
        public async Task HandleAsync(UpdateToDoItemAction action, IDispatcher dispatcher)
        {
            try
            {
                ApiResponseDto apiResponse = await _httpClient.PutJsonAsync<ApiResponseDto>("api/todo", action.TodoDto);
                await Task.Delay(2000); // simulate long roundtrip time

                if (!apiResponse.IsError)
                {
                    dispatcher.Dispatch(new UpdateToDoItemResultAction(action.TodoDto, true, null));
                }
                else
                {
                    dispatcher.Dispatch(new UpdateToDoItemResultAction(null, false, apiResponse.Message + " : " + apiResponse.StatusCode));
                }
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new UpdateToDoItemResultAction(null, false, e.Message));
            }
        }

        [EffectMethod]
        public Task HandleAsync(UpdateToDoItemResultAction action, IDispatcher dispatcher)
        {
            // clear selection:
            dispatcher.Dispatch(new EditByIdToDoItemAction(null));
            // dispatcher.Dispatch(new DetailByIdToDoItemAction(null));

            // reload todo items
            //dispatcher.Dispatch(new GetToDoItemsAction());

            // let FetchToDoState update the item in its collection:
            dispatcher.Dispatch(new FetchToDo.ToDoItemSideEffects.UpdateToDoItemAction(action.TodoDto));

            // special: set as active detail view item
            // dispatcher.Dispatch(new DetailByIdToDoItemAction(action.TodoDto.Id));

            // TODO: refresh active detail item (if it was set before!)
            dispatcher.Dispatch(new RefreshDetailToDoItemAction(action.TodoDto.Id));

            // TODO: move back into component?
            _matToaster.Add("Update Success", MatToastType.Success, "Todo item updated");

            return Task.CompletedTask;
        }
    }
}