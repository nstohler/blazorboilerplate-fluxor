using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;
using BlazorBoilerplate.Client.Store.Counter.Increment;

namespace BlazorBoilerplate.Client.Store.Counter
{
    public class CounterEffects
    {
        private readonly HttpClient _httpClient;

        public CounterEffects(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [EffectMethod]
        public async Task HandleAsync(IncrementCounterAction action, IDispatcher dispatcher)
        {
            try
            {
                Console.WriteLine("CounterEffect IncrementCounterAction");
                await Task.Delay(500);

                dispatcher.Dispatch(new IncrementCounterResultAction(action.PrevCount + 1, true, null));
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new IncrementCounterResultAction(0, false, "simulated http fetch failed somehow"));
            }
        }
    }
}
