using System;
using BlazorBoilerplate.Client.Store.Extensions;
using BlazorBoilerplate.Client.Store.ToDoItem.Update;
using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.ToDoItem.CreateNew
{
    public class CreateNewToDoItemAction :
        ComponentNotificationActionBase<CreateNewToDoItemResultAction>,
        IActionWithSideEffect
    {
        public TodoDto AddTodo { get; }

        public CreateNewToDoItemAction(TodoDto addTodo, Action<CreateNewToDoItemResultAction> notificationAction) 
            : base(notificationAction)
        {
            AddTodo = addTodo;
        }
    }
}
