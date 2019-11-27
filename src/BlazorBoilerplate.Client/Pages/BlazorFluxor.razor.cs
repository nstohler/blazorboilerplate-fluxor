using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;
using Blazor.Fluxor.Components;
using BlazorBoilerplate.Client.Store.BlazorFluxor;
using BlazorBoilerplate.Client.Store.BlazorFluxor.EditById;
using BlazorBoilerplate.Client.Store.Counter;
using BlazorBoilerplate.Client.Store.Counter.Increment;
using BlazorBoilerplate.Client.Store.Counter.Report;
using BlazorBoilerplate.Client.Store.FetchToDo;
using BlazorBoilerplate.Client.Store.FetchToDo.Get;
using BlazorBoilerplate.Client.Store.UpsertToDoItem;
using BlazorBoilerplate.Client.Store.UpsertToDoItem.CreateNew;
using BlazorBoilerplate.Client.Store.UpsertToDoItem.Update;
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
        [Inject] protected IState<ICounterState> CounterState { get; set; }
        [Inject] protected IState<FetchToDoItemsState> FetchToDoItemsState { get; set; }
        [Inject] protected IState<IBlazorFluxorState> BlazorFluxorState { get; set; }
        [Inject] protected IState<IUpsertToDoItemState> UpsertToDoItemState { get; set; }

        [Inject] protected IObservableStore ObservableStore { get; set; }

        protected TodoDto addTodo { get; set; } = new TodoDto();

        private List<IDisposable> _subscriptions = new List<IDisposable>();

        protected override void OnInitialized()
        {
            base.OnInitialized();

            var sub = this.ObservableStore.Actions
                .TakeAction<IncrementCounterSuccessAction>()
                .Subscribe(action =>
                {
                    Console.WriteLine($"ObservableStore.Actions for IncrementCounterSuccessAction @ BlazorFluxor.razor.cs | counter is {CounterState.Value.CurrentCount} / {action.ServerCount}");
                    this.ClearAddForm();
                    base.StateHasChanged();
                });

            _subscriptions.Add(sub);


            ////CounterState.Subscribe(this);
            ////FetchToDoItemsState.Subscribe(this);

            //FetchToDoItemsState.StateChanged += OnFetchToDoItemsStateOnStateChanged;
            //UpsertToDoItemState.StateChanged += OnUpsertToDoItemStateOnStateChanged;

            if (FetchToDoItemsState.Value.ToDoItems == null)
            {
                Dispatcher.Dispatch(new GetToDoItemsAction());
            }
        }

        //private void OnUpsertToDoItemStateOnStateChanged(object sender, IUpsertToDoItemState e)
        //{
        //    //Console.WriteLine($"OnUpsertToDoItem state has changed! isUpdating: {UpsertToDoItemState.Value.IsProcessing} - {e.IsProcessing} | {sender.ToString()} | {sender.GetType().Name}");
        //    Console.WriteLine($"OnUpsertToDoItem state has changed! isUpdating: {UpsertToDoItemState.Value.IsProcessing} - {e.IsProcessing}");
        //    if (!e.IsProcessing && e.ErrorMessage == null)
        //    {
        //        // insert/update/delete just completed
        //        // show a toast or something...
        //        Console.WriteLine($"TOAST: insert/update/delete operation successfully completed");
        //    }
        //}

        //private void OnFetchToDoItemsStateOnStateChanged(object sender, FetchToDoItemsState state)
        //{
        //    Console.WriteLine("ToDoItem state has changed!");
        //}

        protected void IncrementCount()
        {
            // Dispatcher.Dispatch(new IncrementCounterAction(CounterState.Value.CurrentCount, this));

            //Dispatcher.Dispatch(new IncrementCounterAction(CounterState.Value.CurrentCount, 
            //    () =>
            //    {
            //        Console.WriteLine($"DoneAction @ BlazorFluxor.razor.cs");

            //        ClearAddForm();
            //        StateHasChanged();
            //    }
            //    ));

            Dispatcher.Dispatch(new IncrementCounterAction(CounterState.Value.CurrentCount, null));

        }

        protected void LoadToDos()
        {
            Dispatcher.Dispatch(new GetToDoItemsAction());
        }

        protected void UpdateTodo(TodoDto toDoItem)
        {
            Dispatcher.Dispatch(new UpsertToDoItemAction(toDoItem));

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
            //FetchToDoItemsState.StateChanged -= OnFetchToDoItemsStateOnStateChanged;
            //UpsertToDoItemState.StateChanged -= OnUpsertToDoItemStateOnStateChanged;
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