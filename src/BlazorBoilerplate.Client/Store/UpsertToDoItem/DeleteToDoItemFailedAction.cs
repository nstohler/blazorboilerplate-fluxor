namespace BlazorBoilerplate.Client.Store.UpsertToDoItem
{
    public class DeleteToDoItemFailedAction
    {
        public string ErrorMessage { get; }

        public DeleteToDoItemFailedAction(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}