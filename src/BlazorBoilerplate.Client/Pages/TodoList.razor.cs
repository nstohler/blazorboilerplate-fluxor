﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;
using Blazor.Fluxor.Components;
using BlazorBoilerplate.Client.Store.DetailEditToDoItem;
using BlazorBoilerplate.Client.Store.Extensions;
using BlazorBoilerplate.Client.Store.FetchToDo;
using BlazorBoilerplate.Client.Store.FetchToDo.Get;
using BlazorBoilerplate.Client.Store.Services;
using BlazorBoilerplate.Client.Store.ToDoItem.CreateNew;
using BlazorBoilerplate.Client.Store.ToDoItem.Delete;
using BlazorBoilerplate.Client.Store.ToDoItem.Update;
using BlazorBoilerplate.Shared.Dto;
using MatBlazor;
using Microsoft.AspNetCore.Components;

namespace BlazorBoilerplate.Client.Pages
{
    public class TodoListBase : FluxorComponent, IDisposable, IFluxorComponentWithReactions
    {
        [Inject] private HttpClient  Http       { get; set; }
        [Inject] private IMatToaster matToaster { get; set; }

        [Inject] protected IDispatcher                  Dispatcher          { get; set; }
        [Inject] protected IState<IFetchToDoItemsState> FetchToDoItemsState { get; set; }

        [Inject] protected ComponentNotifierService ComponentNotifierService { get; set; }

    protected TodoDto createTodo = new TodoDto();
        protected TodoDto deleteTodo = null;

        protected bool deleteDialogOpen = false;
        protected bool dialogIsOpen     = false;

        protected override void OnInitialized()
        {
            base.OnInitialized();

            ComponentNotifierService.Register(this);

            LoadTodos();
        }

        protected void LoadTodos()
        {
            Dispatcher.Dispatch(new GetToDoItemsAction()
                {
                    NotificationAction = action =>
                    {
                        Console.WriteLine($"ResultAction invoked!");
                        if (action.IsSuccess)
                        {
                            matToaster.Add($"Loaded {action.ToDoDoItems.Count} todos", MatToastType.Success);
                        }
                        else
                        {
                            matToaster.Add(action.ErrorMessage, MatToastType.Danger,
                                "Error loading todos");
                        }
                    }
                }
            );
        }

        public void ForwardAction(GetToDoItemsResultAction action)
        {
            Console.WriteLine($"ResultAction (ForwardAction) invoked!");
            if (action.IsSuccess)
            {
                matToaster.Add($"Loaded {action.ToDoDoItems.Count} todos", MatToastType.Success);
            }
            else
            {
                matToaster.Add(action.ErrorMessage, MatToastType.Danger,
                    "Error loading todos");
            }
        }

        protected async Task Update(TodoDto todo)
        {
            var updateTodo = todo;
            updateTodo.IsCompleted = !updateTodo.IsCompleted;

            var updateAction = new UpdateToDoItemAction(updateTodo)
            {
                NotificationAction = action =>
                {
                    Console.WriteLine($"-- Update TODO: Observable UpdateToDoItemResultAction");
                    if (action.IsSuccess)
                    {
                        matToaster.Add("Updated ToDo", MatToastType.Success);
                    }
                    else
                    {
                        if (updateTodo != null)
                        {
                            updateTodo.IsCompleted = !updateTodo.IsCompleted; // reset upon save failure
                        }

                        todo.IsCompleted = !todo.IsCompleted; //update failed so reset IsCompleted
                        matToaster.Add(action.ErrorMessage, MatToastType.Danger, "Todo Save Failed");
                        updateTodo = null;
                    }
                }
            };


            Dispatcher.Dispatch(updateAction);

            //Dispatcher.Dispatch(new UpdateToDoItemAction(updateTodo, action =>
            //{
            //    Console.WriteLine($"-- Update TODO: Observable UpdateToDoItemResultAction");
            //    if (action.IsSuccess)
            //    {
            //        matToaster.Add("Updated ToDo", MatToastType.Success);
            //    }
            //    else
            //    {
            //        if (updateTodo != null)
            //        {
            //            updateTodo.IsCompleted = !updateTodo.IsCompleted;   // reset upon save failure
            //        }

            //        todo.IsCompleted = !todo.IsCompleted; //update failed so reset IsCompleted
            //        matToaster.Add(action.ErrorMessage, MatToastType.Danger, "Todo Save Failed");
            //        updateTodo = null;
            //    }
            //}));
        }

        protected async Task Delete()
        {
            if (deleteTodo == null)
            {
                return;
            }

            Dispatcher.Dispatch(new DeleteToDoItemAction(deleteTodo)
            {
                NotificationAction = action =>
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
                    deleteTodo       = null;
                }
            });
        }

        protected void OpenDialog()
        {
            dialogIsOpen = true;
        }

        protected void OpenDeleteDialog(long todoId)
        {
            deleteTodo = FetchToDoItemsState.Value.ToDoItems.FirstOrDefault(x => x.Id == todoId);
            if (deleteTodo != null)
            {
                this.deleteDialogOpen = true;
            }
        }

        protected async Task CreateTodo()
        {
            Dispatcher.Dispatch(new CreateNewToDoItemAction(createTodo)
            {
                NotificationAction = action =>
                {
                    if (action.IsSuccess)
                    {
                        matToaster.Add("Created ToDo", MatToastType.Success);
                        dialogIsOpen = false;
                        createTodo   = new TodoDto(); //reset todo after insert
                    }
                    else
                    {
                        matToaster.Add(action.ErrorMessage, MatToastType.Danger, "Todo Creation Failed");
                    }
                }
            });
        }

        public void Dispose()
        {
            ComponentNotifierService.Unregister(this);
        }
    }
}