using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.UpsertToDoItem
{
    public class UpsertToDoItemFeature : Feature<IUpsertToDoItemState>
    {
        public override string GetName() => "UpsertToDoItem";

        //protected override IUpsertToDoItemState GetInitialState() => new UpsertToDoItemState(false, null, null, ToDoItemOperation.None);
        protected override IUpsertToDoItemState GetInitialState() => UpsertToDoItemState.CreateNew();
    }
}