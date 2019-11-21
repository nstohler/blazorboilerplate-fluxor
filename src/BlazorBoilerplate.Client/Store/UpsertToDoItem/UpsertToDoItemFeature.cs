using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.UpsertToDoItem
{
    public class UpsertToDoItemFeature : Feature<UpsertToDoItemState>
    {
        public override string GetName() => "UpsertToDoItem";

        protected override UpsertToDoItemState GetInitialState() => new UpsertToDoItemState(false, null, null);
    }
}