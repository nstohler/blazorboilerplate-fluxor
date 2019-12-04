using System;
using System.Collections.Generic;
using Blazor.Fluxor;
using Blazor.Fluxor.Components;
using BlazorBoilerplate.Client.Store.Counter;
using BlazorBoilerplate.Client.Store.Counter.Increment;
using BlazorBoilerplate.Client.Store.DetailEditToDoItem;
using BlazorBoilerplate.Client.Store.DetailEditToDoItem.Edit;
using BlazorBoilerplate.Client.Store.Extensions;
using BlazorBoilerplate.Client.Store.FetchToDo;
using BlazorBoilerplate.Client.Store.FetchToDo.Get;
using BlazorBoilerplate.Client.Store.Services;
using BlazorBoilerplate.Client.Store.ToDoItem;
using BlazorBoilerplate.Client.Store.ToDoItem.CreateNew;
using BlazorBoilerplate.Client.Store.ToDoItem.Update;
using BlazorBoilerplate.Shared.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace BlazorBoilerplate.Client.Pages
{
    // https://www.telerik.com/blogs/using-a-code-behind-approach-to-blazor-components

    [Authorize]
    public class BlazorFluxorBase : FluxorComponent, IDisposable, IFluxorComponentWithReactions // , INotifyBlazorComponent
    {
        [Inject] protected IDispatcher Dispatcher { get; set; }

        [Inject] protected IState<ICounterState>            CounterState            { get; set; }
        [Inject] protected IState<IFetchToDoItemsState>     FetchToDoItemsState     { get; set; }
        [Inject] protected IState<IDetailEditToDoItemState> DetailEditToDoItemState { get; set; }
        [Inject] protected IState<IToDoItemState>           ToDoItemState           { get; set; }

        [Inject] protected ComponentNotifierService ComponentNotifierService { get; set; }

        protected TodoDto addTodo { get; set; } = new TodoDto();

        protected override void OnInitialized()
        {
            base.OnInitialized();

            ComponentNotifierService.Register(this);

            if (FetchToDoItemsState.Value.ToDoItems == null)
            {
                Dispatcher.Dispatch(new GetToDoItemsAction());
            }
        }

        protected void IncrementCount()
        {
            Dispatcher.Dispatch(new IncrementCounterAction(CounterState.Value.CurrentCount));
        }

        protected void LoadToDos()
        {
            Dispatcher.Dispatch(new GetToDoItemsAction());
        }

        protected void UpdateTodo(TodoDto toDoItem)
        {
            Dispatcher.Dispatch(new UpdateToDoItemAction(toDoItem));

            // report back success after done...
        }

        protected void CancelSelection()
        {
            Dispatcher.Dispatch(new EditByIdToDoItemAction(null));
        }

        protected void CreateTodo()
        {
            Dispatcher.Dispatch(new CreateNewToDoItemAction(this.addTodo)
            {
                NotificationAction = action =>
                {
                    if (action.IsSuccess)
                    {
                        ClearAddForm();
                        StateHasChanged();
                    }
                }
            });
        }

        public void Dispose()
        {
            Console.WriteLine("Disposing...");

            ComponentNotifierService.Unregister(this);

            // disconnect events
            //ToDoItemState.StateChanged -= OnToDoItemStateOnStateChanged;
        }

        protected void ClearAddForm()
        {
            this.addTodo = new TodoDto();
        }
    }
}