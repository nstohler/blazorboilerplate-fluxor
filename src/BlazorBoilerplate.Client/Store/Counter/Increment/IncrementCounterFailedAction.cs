namespace BlazorBoilerplate.Client.Store.Counter.Increment
{
    public class IncrementCounterFailedAction
    {
        public IncrementCounterFailedAction(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; private set; }


    }
}
