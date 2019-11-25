using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.Counter
{
    public class CounterFeature : Feature<ICounterState>
    {
        public override string GetName() => "Counter";

        protected override ICounterState GetInitialState() => new CounterState(false, false, null, 0);
    }
}