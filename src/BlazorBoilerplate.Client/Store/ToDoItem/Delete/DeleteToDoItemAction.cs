using System;
using BlazorBoilerplate.Client.Store.Extensions;
using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.ToDoItem.Delete
{
    public class DeleteToDoItemAction :
        ComponentNotificationActionBase<DeleteToDoItemResultAction>,
        IActionWithSideEffect
    {
        public TodoDto TodoDto { get; private set; }

        public DeleteToDoItemAction(TodoDto todoDto, Action<DeleteToDoItemResultAction> notificationAction)
            : base(notificationAction)
        {
            TodoDto = todoDto;
        }
    }
}