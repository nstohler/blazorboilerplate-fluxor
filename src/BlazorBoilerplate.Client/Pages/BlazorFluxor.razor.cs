using System;
using System.Collections.Generic;
using Blazor.Fluxor;
using Blazor.Fluxor.Components;
using BlazorBoilerplate.Client.Store.Counter;
using BlazorBoilerplate.Client.Store.Counter.Increment;
using BlazorBoilerplate.Client.Store.DetailEditToDoItem;
using BlazorBoilerplate.Client.Store.DetailEditToDoItem.Edit;
using BlazorBoilerplate.Client.Store.FetchToDo;
using BlazorBoilerplate.Client.Store.FetchToDo.Get;
using BlazorBoilerplate.Client.Store.ToDoItem;
using BlazorBoilerplate.Client.Store.ToDoItem.CreateNew;
using BlazorBoilerplate.Client.Store.ToDoItem.Update;
using BlazorBoilerplate.Shared.Dto;
using Logixware.AspNet.Blazor.Fluxor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace BlazorBoilerplate.Client.Pages
{
    // https://www.telerik.com/blogs/using-a-code-behind-approach-to-blazor-components

    [Authorize]
    public class BlazorFluxorBase : FluxorComponent, IDisposable // , INotifyBlazorComponent
    {
        [Inject] protected IDispatcher Dispatcher { get; set; }

        [Inject] protected IState<ICounterState>            CounterState            { get; set; }
        [Inject] protected IState<IFetchToDoItemsState>     FetchToDoItemsState     { get; set; }
        [Inject] protected IState<IDetailEditToDoItemState> DetailEditToDoItemState { get; set; }
        [Inject] protected IState<IToDoItemState>           ToDoItemState           { get; set; }

        [Inject] protected IObservableStore ObservableStore { get; set; }

        protected TodoDto addTodo { get; set; } = new TodoDto();

        private List<IDisposable> _subscriptions = new List<IDisposable>();

        protected override void OnInitialized()
        {
            base.OnInitialized();

            //ToDoItemState.StateChanged += OnToDoItemStateOnStateChanged;

            //var sub = this.ObservableStore.Actions
            //    .TakeAction<IncrementCounterResultAction>()
            //    .Subscribe(action =>
            //    {
            //        Console.WriteLine(
            //            $"ObservableStore.Actions for IncrementCounterResultAction @ BlazorFluxor.razor.cs | counter is {CounterState.Value.CurrentCount} / {action.Count}");
            //        ClearAddForm();
            //        StateHasChanged();
            //    });

            var sub = this.ObservableStore.Actions
                .TakeAction<CreateNewToDoItemResultAction>()
                .Subscribe(action =>
                {
                    if (action.IsSuccess)
                    {
                        ClearAddForm();
                        StateHasChanged();
                    }
                });

            _subscriptions.Add(sub);

            if (FetchToDoItemsState.Value.ToDoItems == null)
            {
                Dispatcher.Dispatch(new GetToDoItemsAction(null));
            }
        }

        protected void IncrementCount()
        {
            Dispatcher.Dispatch(new IncrementCounterAction(CounterState.Value.CurrentCount));
        }

        protected void LoadToDos()
        {
            Dispatcher.Dispatch(new GetToDoItemsAction(null));
        }

        protected void UpdateTodo(TodoDto toDoItem)
        {
            Dispatcher.Dispatch(new UpdateToDoItemAction(toDoItem, null));

            // report back success after done...
        }

        protected void CancelSelection()
        {
            Dispatcher.Dispatch(new EditByIdToDoItemAction(null));
        }

        protected void CreateTodo()
        {
            Dispatcher.Dispatch(new CreateNewToDoItemAction(this.addTodo));
        }

        public void Dispose()
        {
            Console.WriteLine("Disposing...");

            // disconnect events
            //ToDoItemState.StateChanged -= OnToDoItemStateOnStateChanged;

            // unsubscribe
            foreach (var subscription in _subscriptions)
            {
                subscription.Dispose();
            }
        }

        protected void ClearAddForm()
        {
            this.addTodo = new TodoDto();
        }
    }
}