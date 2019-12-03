using System;
using BlazorBoilerplate.Client.Store.Extensions;
using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.ToDoItem.Update
{
    public class UpdateToDoItemAction : 
        ComponentNotificationActionBase<UpdateToDoItemResultAction>,
        IActionWithSideEffect
    {
        public TodoDto TodoDto { get; private set; }

        public UpdateToDoItemAction(TodoDto todoDto, Action<UpdateToDoItemResultAction> notificationAction)
            : base(notificationAction)
        {
            TodoDto = todoDto;
        }
    }
}