using System;
using System.Text.Json.Serialization;
using BlazorBoilerplate.Client.Store.Extensions;
using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.ToDoItem.Delete
{
    public class DeleteToDoItemAction :
        IHasNotificationAction<DeleteToDoItemResultAction>,
        IActionWithSideEffect
    {
        public TodoDto TodoDto { get; private set; }

        public DeleteToDoItemAction(TodoDto todoDto)
        {
            TodoDto = todoDto;
        }

        [JsonIgnore] public Action<DeleteToDoItemResultAction> NotificationAction { get; set; }
    }
}