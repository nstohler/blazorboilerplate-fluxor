using System;
using System.Text.Json.Serialization;
using BlazorBoilerplate.Client.Store.Extensions;

namespace BlazorBoilerplate.Client.Store.FetchToDo.Get
{
    public class GetToDoItemsAction :
        IHasNotificationAction<GetToDoItemsResultAction>,
        IActionWithSideEffect
    {
        [JsonIgnore] public Action<GetToDoItemsResultAction> NotificationAction { get; set; }
    }
}