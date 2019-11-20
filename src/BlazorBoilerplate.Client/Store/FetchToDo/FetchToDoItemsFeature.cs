using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.FetchToDo
{
    public class FetchToDoItemsFeature : Feature<FetchToDoItemsState>
    {
        public override string GetName() => "FetchToDoItems";
        
        protected override FetchToDoItemsState GetInitialState() => new FetchToDoItemsState(
            false, 
            null,
            null
            );
    }
}
