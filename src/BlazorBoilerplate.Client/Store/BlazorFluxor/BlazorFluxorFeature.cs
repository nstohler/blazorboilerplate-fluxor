using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.BlazorFluxor
{
    public class BlazorFluxorFeature : Feature<BlazorFluxorState>
    {
        public override string GetName() => "BlazorFluxorComponent";
        
        protected override BlazorFluxorState GetInitialState() => new BlazorFluxorState(
            null, 
            null
            );
    }
}
