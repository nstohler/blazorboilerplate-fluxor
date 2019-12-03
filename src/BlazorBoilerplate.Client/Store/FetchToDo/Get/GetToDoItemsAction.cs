using System;
using BlazorBoilerplate.Client.Store.Extensions;

namespace BlazorBoilerplate.Client.Store.FetchToDo.Get
{
    public class GetToDoItemsAction : ComponentNotificationActionBase<GetToDoItemsResultAction>, IActionWithSideEffect
    {
        public GetToDoItemsAction(Action<GetToDoItemsResultAction> notificationAction) 
            : base(notificationAction)
        {
        }
    }
}