using System;
using System.Text.Json.Serialization;
using BlazorBoilerplate.Client.Store.Extensions;
using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.ToDoItem.Delete
{
    public class DeleteToDoItemResultAction :
        IHasExecuteNotifyComponent<DeleteToDoItemResultAction>,
        IActionWithSideEffect
    {
        public DeleteToDoItemResultAction(Action<DeleteToDoItemResultAction> notificationAction,
            TodoDto todoDto, bool isSuccess, string errorMessage)
        {
            NotificationAction = notificationAction;
            TodoDto            = todoDto;
            IsSuccess          = isSuccess;
            ErrorMessage       = errorMessage;
        }

        public TodoDto TodoDto      { get; private set; }
        public bool    IsSuccess    { get; private set; }
        public string  ErrorMessage { get; private set; }

        [JsonIgnore] public Action<DeleteToDoItemResultAction> NotificationAction { get; private set; }

        public void ExecuteNotifyComponent()
        {
            NotificationAction?.Invoke(this);
        }
    }
}