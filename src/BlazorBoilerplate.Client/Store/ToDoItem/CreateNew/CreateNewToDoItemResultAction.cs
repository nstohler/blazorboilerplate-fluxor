using System;
using System.Text.Json.Serialization;
using BlazorBoilerplate.Client.Store.Extensions;
using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.ToDoItem.CreateNew
{
    public class CreateNewToDoItemResultAction :
        IHasExecuteNotifyComponent<CreateNewToDoItemResultAction>,
        IActionWithSideEffect
    {
        public CreateNewToDoItemResultAction(
            Action<CreateNewToDoItemResultAction> notificationAction,
            TodoDto todo, bool isSuccess, string errorMessage)
        {
            NotificationAction = notificationAction;
            Todo               = todo;
            IsSuccess          = isSuccess;
            ErrorMessage       = errorMessage;
        }

        public TodoDto Todo         { get; private set; }
        public bool    IsSuccess    { get; private set; }
        public string  ErrorMessage { get; private set; }

        [JsonIgnore] public Action<CreateNewToDoItemResultAction> NotificationAction { get; private set; }

        public void ExecuteNotifyComponent()
        {
            NotificationAction?.Invoke(this);
        }
    }
}