using BlazorBoilerplate.Client.Store.Extensions;
using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.ToDoItem.Update
{
    public class UpdateToDoItemResultAction : ComponentNotificationActionBase<UpdateToDoItemResultAction>, IActionWithSideEffect
    {
        public UpdateToDoItemResultAction(ComponentNotificationActionBase<UpdateToDoItemResultAction> componentNotificationAction, TodoDto todoDto, bool isSuccess, string errorMessage) 
            : base(componentNotificationAction)
        {
            TodoDto      = todoDto;
            IsSuccess    = isSuccess;
            ErrorMessage = errorMessage;
        }

        public TodoDto TodoDto      { get; private set; }
        public bool    IsSuccess    { get; private set; }
        public string  ErrorMessage { get; private set; }
    }
}