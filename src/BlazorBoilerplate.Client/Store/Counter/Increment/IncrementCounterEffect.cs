using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.Counter.Increment
{
    //public class IncrementCounterEffect : Effect<IncrementCounterAction>
    //{
    //    private readonly HttpClient _httpClient;

    //    public IncrementCounterEffect(HttpClient httpClient)
    //    {
    //        _httpClient = httpClient;
    //    }

    //    protected override async Task HandleAsync(IncrementCounterAction action, IDispatcher dispatcher)
    //    {
    //        try
    //        {
    //            await Task.Delay(1000);
    //            dispatcher.Dispatch(new IncrementCounterSuccessAction(action.PrevCount + 1));
    //        }
    //        catch (Exception e)
    //        {
    //            dispatcher.Dispatch(new IncrementCounterFailedAction("simulated http fetch failed somehow"));
    //        }
    //    }
    //}
}
