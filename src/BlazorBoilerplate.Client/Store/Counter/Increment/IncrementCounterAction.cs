using BlazorBoilerplate.Client.Pages;
using BlazorBoilerplate.Client.Store.Counter.Report;

namespace BlazorBoilerplate.Client.Store.Counter.Increment
{
    public class IncrementCounterAction
    {
        private readonly INotifyBlazorComponent _notifyBlazorComponent;

        public IncrementCounterAction(int prevCount, INotifyBlazorComponent notifyBlazorComponent)
        {
            NotifyBlazorComponent = notifyBlazorComponent;
            PrevCount = prevCount;
        }
        // empty

        public int PrevCount { get; private set; }
        public INotifyBlazorComponent NotifyBlazorComponent { get; private set; }
    }
}
