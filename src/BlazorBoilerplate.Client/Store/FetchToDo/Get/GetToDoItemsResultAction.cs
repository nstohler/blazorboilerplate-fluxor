using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BlazorBoilerplate.Client.Store.Extensions;
using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.FetchToDo.Get
{
    public class GetToDoItemsResultAction : IHasComponentNotificationAction, IActionWithSideEffect
    {
        public GetToDoItemsResultAction(GetToDoItemsAction action, List<TodoDto> toDoItems,
            bool isSuccess, string errorMessage)
        {
            Action       = action;
            ToDoDoItems  = toDoItems;
            IsSuccess    = isSuccess;
            ErrorMessage = errorMessage;
        }

        [JsonIgnore] private GetToDoItemsAction Action { get; set; }

        public List<TodoDto> ToDoDoItems  { get; private set; }
        public bool          IsSuccess    { get; private set; }
        public string        ErrorMessage { get; private set; }

        public void InvokeAction()
        {
            Action?.NotificationAction?.Invoke(this);
        }
    }
}