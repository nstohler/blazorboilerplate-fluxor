using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.ToDoItem.Update
{
    public class UpdateToDoItemResultAction
    {
        public UpdateToDoItemResultAction(TodoDto todoDto, bool isSuccess, string errorMessage)
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