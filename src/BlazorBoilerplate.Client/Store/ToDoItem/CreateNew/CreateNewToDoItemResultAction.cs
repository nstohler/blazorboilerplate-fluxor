using BlazorBoilerplate.Client.Store.Extensions;
using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.ToDoItem.CreateNew
{
    public class CreateNewToDoItemResultAction :
        ComponentNotificationActionBase<CreateNewToDoItemResultAction>,
        IActionWithSideEffect
    {
        public CreateNewToDoItemResultAction(
            ComponentNotificationActionBase<CreateNewToDoItemResultAction> componentNotificationActionBase,
            TodoDto todo, bool isSuccess, string errorMessage)
            : base(componentNotificationActionBase)
        {
            Todo         = todo;
            IsSuccess    = isSuccess;
            ErrorMessage = errorMessage;
        }

        public TodoDto Todo         { get; private set; }
        public bool    IsSuccess    { get; private set; }
        public string  ErrorMessage { get; private set; }
    }
}