using System;
using System.Text.Json.Serialization;
using BlazorBoilerplate.Client.Store.Extensions;
using BlazorBoilerplate.Client.Store.ToDoItem.Update;
using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.ToDoItem.CreateNew
{
    public class CreateNewToDoItemAction :
        IHasNotificationAction<CreateNewToDoItemResultAction>,
        IActionWithSideEffect
    {
        public TodoDto AddTodo { get; }

        public CreateNewToDoItemAction(TodoDto addTodo)
        {
            AddTodo = addTodo;
        }

        [JsonIgnore] public Action<CreateNewToDoItemResultAction> NotificationAction { get; set; }
    }
}
