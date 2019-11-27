namespace BlazorBoilerplate.Client.Store.Counter.Increment
{
    //public class IncrementCounterFailedAction
    //{
    //    public IncrementCounterFailedAction(bool isSuccess, string errorMessage)
    //    {
    //        IsSuccess    = isSuccess;
    //        ErrorMessage = errorMessage;
    //    }

    //    public bool   IsSuccess    { get; private set; }
    //    public string ErrorMessage { get; private set; }
    //}

    public class IncrementCounterResultAction
    {
        public IncrementCounterResultAction(int count, bool isSuccess, string errorMessage)
        {
            IsSuccess    = isSuccess;
            ErrorMessage = errorMessage;
            Count        = count;
        }

        public int    Count        { get; private set; }
        public bool   IsSuccess    { get; private set; }
        public string ErrorMessage { get; private set; }
    }
}