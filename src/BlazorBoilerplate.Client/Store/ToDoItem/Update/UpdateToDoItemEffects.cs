using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazor.Fluxor;
using BlazorBoilerplate.Client.Store.Services;
using BlazorBoilerplate.Shared.Dto;
using MatBlazor;
using Microsoft.AspNetCore.Components;

namespace BlazorBoilerplate.Client.Store.ToDoItem.Update
{
    public class UpdateToDoItemEffects
    {
        private readonly HttpClient               _httpClient;
        private readonly ComponentNotifierService _componentNotifierService;

        //private readonly IMatToaster _matToaster;

        public UpdateToDoItemEffects(HttpClient httpClient, ComponentNotifierService componentNotifierService)
        {
            _httpClient               = httpClient;
            _componentNotifierService = componentNotifierService;
            //_matToaster = matToaster;
        }

        [EffectMethod]
        public async Task HandleAsync(UpdateToDoItemAction action, IDispatcher dispatcher)
        {
            try
            {
                Console.WriteLine($"==> EFFECT: UpdateToDoItemAction: update on server");
                ApiResponseDto apiResponse = await _httpClient.PutJsonAsync<ApiResponseDto>("api/todo", action.TodoDto);
                await Task.Delay(2000); // simulate long roundtrip time

                if (!apiResponse.IsError)
                {
                    dispatcher.Dispatch(new UpdateToDoItemResultAction(action, action.TodoDto, true,
                        null));
                }
                else
                {
                    dispatcher.Dispatch(new UpdateToDoItemResultAction(action, null, false,
                        apiResponse.Message + " : " + apiResponse.StatusCode));
                }
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new UpdateToDoItemResultAction(action, null, false, e.Message));
            }
            finally
            {
                Console.WriteLine($"   ==> EFFECT: UpdateToDoItemAction: update on server DONE");
            }
        }

        [EffectMethod]
        public Task HandleAsync(UpdateToDoItemResultAction action, IDispatcher dispatcher)
        {
            Console.WriteLine($"==> EFFECT: UpdateToDoItemResultAction: dispatch actions to other listeners");
            // clear selection:
            dispatcher.Dispatch(new Store.DetailEditToDoItem.Edit.EditByIdToDoItemAction(null));
            // dispatcher.Dispatch(new DetailByIdToDoItemAction(null));

            // reload todo items
            //dispatcher.Dispatch(new GetToDoItemsAction());

            // let FetchToDoState update the item in its collection:
            dispatcher.Dispatch(new FetchToDo.ToDoItemSideEffects.UpdateToDoItemAction(action.TodoDto));

            // special: set as active detail view item
            // dispatcher.Dispatch(new DetailByIdToDoItemAction(action.TodoDto.Id));

            // TODO: refresh active detail item (if it was set before!)
            dispatcher.Dispatch(
                new Store.DetailEditToDoItem.RefreshDetail.RefreshDetailToDoItemAction(action.TodoDto.Id));

            // TODO: move back into component?
            //_matToaster.Add("Update Success", MatToastType.Success, "Todo item updated");

            Console.WriteLine($"   ==> EFFECT: UpdateToDoItemResultAction: dispatch actions to other listeners DONE");

            //action.ExecuteNotifyComponent();
            _componentNotifierService.ForwardAction(action);

            return Task.CompletedTask;
        }
    }
}