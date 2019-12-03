using System;
using System.Text.Json.Serialization;
using BlazorBoilerplate.Client.Store.Extensions;
using BlazorBoilerplate.Shared.Dto;
using EnsureThat;

namespace BlazorBoilerplate.Client.Store.ToDoItem.Update
{
    public class UpdateToDoItemResultAction : 
        IHasExecuteNotifyComponent<UpdateToDoItemResultAction>, 
        IActionWithSideEffect
    {
        public UpdateToDoItemResultAction(Action<UpdateToDoItemResultAction> notificationAction, TodoDto todoDto,
            bool isSuccess, string errorMessage)
        {
            NotificationAction = notificationAction;
            TodoDto            = todoDto;
            IsSuccess          = isSuccess;
            ErrorMessage       = errorMessage;
        }

        public TodoDto TodoDto      { get; private set; }
        public bool    IsSuccess    { get; private set; }
        public string  ErrorMessage { get; private set; }

        [JsonIgnore] public Action<UpdateToDoItemResultAction> NotificationAction { get; private set; }

        public void ExecuteNotifyComponent()
        {
            NotificationAction?.Invoke(this);
        }
    }
}