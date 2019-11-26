using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;
using BlazorBoilerplate.Client.Store.Counter.Increment;
using BlazorBoilerplate.Client.Store.Counter.Report;

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
                Console.WriteLine("CopunterEffect IncrementCounterAction");
                await Task.Delay(500);
                dispatcher.Dispatch(new IncrementCounterSuccessAction(action.PrevCount + 1));
                dispatcher.Dispatch(new ReportBackToBlazorAction());
            }
            catch (Exception e)
            {
                dispatcher.Dispatch(new IncrementCounterFailedAction("simulated http fetch failed somehow"));
            }
        }
    }
}
