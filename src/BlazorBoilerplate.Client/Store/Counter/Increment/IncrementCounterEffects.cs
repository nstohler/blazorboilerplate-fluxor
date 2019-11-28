using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.Counter.Increment
{
    public class IncrementCounterEffects
    {
        private readonly HttpClient _httpClient;

        public IncrementCounterEffects(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [EffectMethod]
        public async Task HandleAsync(IncrementCounterAction action, IDispatcher dispatcher)
        {
            try
            {
                Console.WriteLine("CounterEffect IncrementCounterAction");
                //await Task.Delay(500);

                dispatcher.Dispatch(new IncrementCounterResultAction(action.PrevCount + 1, true, null));
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new IncrementCounterResultAction(0, false, "simulated http fetch failed somehow"));
            }
        }
    }
}
