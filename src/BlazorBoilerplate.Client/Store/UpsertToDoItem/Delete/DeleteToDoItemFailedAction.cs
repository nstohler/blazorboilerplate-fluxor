namespace BlazorBoilerplate.Client.Store.UpsertToDoItem.Delete
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