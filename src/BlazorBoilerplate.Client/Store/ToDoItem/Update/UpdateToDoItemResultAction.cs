using System;
using System.Text.Json.Serialization;
using BlazorBoilerplate.Client.Store.Extensions;
using BlazorBoilerplate.Shared.Dto;
using EnsureThat;

namespace BlazorBoilerplate.Client.Store.ToDoItem.Update
{
    public class UpdateToDoItemResultAction : IHasComponentNotificationAction, IActionWithSideEffect
    {
        public UpdateToDoItemResultAction(UpdateToDoItemAction action,
            TodoDto todoDto, bool isSuccess, string errorMessage)
        {
            Action       = action;
            TodoDto      = todoDto;
            IsSuccess    = isSuccess;
            ErrorMessage = errorMessage;
        }

        [JsonIgnore] private UpdateToDoItemAction Action { get; set; }

        public TodoDto TodoDto      { get; private set; }
        public bool    IsSuccess    { get; private set; }
        public string  ErrorMessage { get; private set; }

        public void InvokeAction()
        {
            Action?.NotificationAction?.Invoke(this);
        }
    }
}