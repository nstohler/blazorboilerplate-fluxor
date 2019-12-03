using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BlazorBoilerplate.Client.Store.Extensions;
using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.FetchToDo.Get
{
    public class GetToDoItemsResultAction :
        IHasExecuteNotifyComponent<GetToDoItemsResultAction>,
        IActionWithSideEffect
    {
        public GetToDoItemsResultAction(Action<GetToDoItemsResultAction> notificationAction, List<TodoDto> toDoItems,
            bool isSuccess, string errorMessage)
        {
            NotificationAction = notificationAction;
            ToDoDoItems        = toDoItems;
            IsSuccess          = isSuccess;
            ErrorMessage       = errorMessage;
        }

        public List<TodoDto> ToDoDoItems  { get; private set; }
        public bool          IsSuccess    { get; private set; }
        public string        ErrorMessage { get; private set; }

        [JsonIgnore] public Action<GetToDoItemsResultAction> NotificationAction { get; private set; }

        public void ExecuteNotifyComponent()
        {
            NotificationAction?.Invoke(this);
        }
    }
}