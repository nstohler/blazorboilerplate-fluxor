namespace BlazorBoilerplate.Client.Store.FetchToDo.Get
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