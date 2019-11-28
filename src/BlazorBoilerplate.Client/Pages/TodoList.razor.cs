using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;
using Blazor.Fluxor.Components;
using BlazorBoilerplate.Client.Store.DetailEditToDoItem;
using BlazorBoilerplate.Client.Store.FetchToDo;
using BlazorBoilerplate.Client.Store.FetchToDo.Get;
using BlazorBoilerplate.Client.Store.ToDoItem.CreateNew;
using BlazorBoilerplate.Client.Store.ToDoItem.Delete;
using BlazorBoilerplate.Client.Store.ToDoItem.Update;
using BlazorBoilerplate.Shared.Dto;
using Logixware.AspNet.Blazor.Fluxor;
using MatBlazor;
using Microsoft.AspNetCore.Components;

namespace BlazorBoilerplate.Client.Pages
{
    public class TodoListBase : FluxorComponent, IDisposable
    {
        [Inject] private HttpClient Http { get; set; }
        [Inject] private IMatToaster matToaster { get; set; }

        [Inject] protected IDispatcher Dispatcher { get; set; }
        [Inject] protected IState<IFetchToDoItemsState> FetchToDoItemsState { get; set; }

        [Inject] protected IObservableStore ObservableStore { get; set; }

        private List<IDisposable> _subscriptions = new List<IDisposable>();
        private IDisposable _createSubscription = null;
        private IDisposable _updateSubscription = null;
        private IDisposable _deleteSubscription = null;

        protected TodoDto createTodo = new TodoDto();
        //protected TodoDto updateTodo = null;
        protected TodoDto deleteTodo = null;

        //---
        protected bool deleteDialogOpen = false;
        protected bool dialogIsOpen = false;

        //protected List<TodoDto> todos => FetchToDoItemsState.Value.ToDoItems.ToList();

        //protected List<TodoDto> todos = new List<TodoDto>();
        //protected TodoDto todo { get; set; } = new TodoDto();

        protected override void OnInitialized()
        {
            base.OnInitialized();

            //var subUpdate = this.ObservableStore.Actions
            //    .TakeAction<UpdateToDoItemResultAction>()
            //    .Subscribe(action =>
            //    {
            //        if (action.IsSuccess)
            //        {
            //            matToaster.Add("Updated ToDo", MatToastType.Success);
            //        }
            //        else
            //        {
            //            if (updateTodo != null)
            //            {
            //                updateTodo.IsCompleted = !updateTodo.IsCompleted;   // reset upon save failure
            //            }

            //            todo.IsCompleted = !todo.IsCompleted; //update failed so reset IsCompleted
            //            matToaster.Add(action.ErrorMessage, MatToastType.Danger, "Todo Save Failed");
            //        }
            //    });

            //_subscriptions.Add(subUpdate);

            Dispatcher.Dispatch(new GetToDoItemsAction());
        }

        //protected override async Task OnInitializedAsync()
        //{
        //    await ReadTodos();
        //}

        //protected async Task ReadTodos()
        //{
        //    ApiResponseDto apiResponse = await Http.GetJsonAsync<ApiResponseDto>("api/todo");

        //    if (apiResponse.StatusCode == 200)
        //    {
        //        matToaster.Add(apiResponse.Message, MatToastType.Success, "Todo List Retrieved");
        //        todos = Newtonsoft.Json.JsonConvert.DeserializeObject<TodoDto[]>(apiResponse.Result.ToString()).ToList<TodoDto>();
        //    }
        //    else
        //    {
        //        matToaster.Add(apiResponse.Message + " : " + apiResponse.StatusCode, MatToastType.Danger, "Todo List Retrieval Failed");
        //    }
        //}

        protected async Task Update(TodoDto todo)
        {
            var updateTodo = todo;
            updateTodo.IsCompleted = !updateTodo.IsCompleted;

            //var clone = FastDeepCloner.DeepCloner.Clone(todo);
            //clone.IsCompleted = !clone.IsCompleted;

            _updateSubscription?.Dispose();

            _updateSubscription = this.ObservableStore.Actions
                .TakeAction<UpdateToDoItemResultAction>()
                .Subscribe(action =>
                {
                    if (action.IsSuccess)
                    {
                        matToaster.Add("Updated ToDo", MatToastType.Success);
                    }
                    else
                    {
                        if (updateTodo != null)
                        {
                            updateTodo.IsCompleted = !updateTodo.IsCompleted;   // reset upon save failure
                        }

                        todo.IsCompleted = !todo.IsCompleted; //update failed so reset IsCompleted
                        matToaster.Add(action.ErrorMessage, MatToastType.Danger, "Todo Save Failed");
                        updateTodo = null;
                    }
                });

            _subscriptions.Add(_updateSubscription);

            Dispatcher.Dispatch(new UpdateToDoItemAction(updateTodo));
        }

        protected async Task Delete()
        {
            if (deleteTodo == null)
            {
                return;
            }

            _deleteSubscription?.Dispose();

            _deleteSubscription = this.ObservableStore.Actions
                .TakeAction<DeleteToDoItemResultAction>()
                .Subscribe(action =>
                {
                    if (action.IsSuccess)
                    {
                        matToaster.Add("Deleted ToDo", MatToastType.Success);
                    }
                    else
                    {
                        matToaster.Add(action.ErrorMessage, MatToastType.Danger, "Todo Delete Failed");
                    }
                    deleteDialogOpen = false;
                    deleteTodo = null;
                });

            _subscriptions.Add(_deleteSubscription);

            Dispatcher.Dispatch(new DeleteToDoItemAction(deleteTodo));
        }

        protected void OpenDialog()
        {
            dialogIsOpen = true;
        }

        protected void OpenDeleteDialog(long todoId)
        {
            deleteTodo = FetchToDoItemsState.Value.ToDoItems.FirstOrDefault(x => x.Id == todoId);
            this.deleteDialogOpen = true;
        }

        protected async Task CreateTodo()
        {

            _createSubscription?.Dispose();

            _createSubscription = this.ObservableStore.Actions
                .TakeAction<CreateNewToDoItemResultAction>()
                .Subscribe(action =>
                {
                    if (action.IsSuccess)
                    {
                        matToaster.Add("Created ToDo", MatToastType.Success);
                        dialogIsOpen = false;
                        createTodo = new TodoDto(); //reset todo after insert
                    }
                    else
                    {
                        matToaster.Add(action.ErrorMessage, MatToastType.Danger, "Todo Creation Failed");
                    }
                });

            _subscriptions.Add(_createSubscription);

            Dispatcher.Dispatch(new CreateNewToDoItemAction(createTodo));

            //dialogIsOpen = false;
            //try
            //{
            //    ApiResponseDto apiResponse = await Http.PostJsonAsync<ApiResponseDto>("api/todo", todo);
            //    if (apiResponse.StatusCode == 200)
            //    {
            //        matToaster.Add(apiResponse.Message, MatToastType.Success);
            //        todo = Newtonsoft.Json.JsonConvert.DeserializeObject<TodoDto>(apiResponse.Result.ToString());
            //        todos.Add(todo);
            //        todo = new TodoDto(); //reset todo after insert
            //    }
            //    else
            //    {
            //        matToaster.Add(apiResponse.Message + " : " + apiResponse.StatusCode, MatToastType.Danger, "Todo Creation Failed");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    matToaster.Add(ex.Message, MatToastType.Danger, "Todo Creation Failed");
            //}
        }

        public void Dispose()
        {
            _createSubscription?.Dispose();
            _updateSubscription?.Dispose();
            _deleteSubscription?.Dispose();

            // unsubscribe
            foreach (var subscription in _subscriptions)
            {
                subscription?.Dispose();
            }
        }
    }
}
