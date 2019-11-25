using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.BlazorFluxor
{
    public class BlazorFluxorFeature : Feature<IBlazorFluxorState>
    {
        public override string GetName() => "BlazorFluxorComponent";
        
        protected override IBlazorFluxorState GetInitialState() => new BlazorFluxorState(
            null,
            null, 
            null,
            null
        );
    }
}
