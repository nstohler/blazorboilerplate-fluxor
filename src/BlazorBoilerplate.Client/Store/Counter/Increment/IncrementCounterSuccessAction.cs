namespace BlazorBoilerplate.Client.Store.Counter.Increment
{
    public class IncrementCounterSuccessAction
    {
        public IncrementCounterSuccessAction(int serverCount)
        {
            ServerCount = serverCount;
        }

        public int ServerCount { get; private set; }
    }
}
