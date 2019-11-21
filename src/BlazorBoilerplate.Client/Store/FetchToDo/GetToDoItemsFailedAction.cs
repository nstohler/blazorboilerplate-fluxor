namespace BlazorBoilerplate.Client.Store.FetchToDo
{
    public class GetToDoItemsFailedAction
    {
        public string ErrorMessage { get; private set; }

        public GetToDoItemsFailedAction(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}