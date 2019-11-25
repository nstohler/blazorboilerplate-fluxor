namespace BlazorBoilerplate.Client.Store.Counter.Increment
{
    public class IncrementCounterAction
    {
        public IncrementCounterAction(int prevCount)
        {
            PrevCount = prevCount;
        }
        // empty

        public int PrevCount { get; private set; }
    }
}
