using System;
using System.Text.Json.Serialization;
using BlazorBoilerplate.Client.Store.Extensions;
using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.ToDoItem.Update
{
    public class UpdateToDoItemAction : //NotificationActionBase<UpdateToDoItemResultAction>,
        IHasNotificationAction<UpdateToDoItemResultAction>, 
        IActionWithSideEffect
    {
        public TodoDto TodoDto { get; private set; }

        public UpdateToDoItemAction(TodoDto todoDto)
        {
            TodoDto = todoDto;
        }

        [JsonIgnore] public Action<UpdateToDoItemResultAction> NotificationAction { get; set; }
    }
}