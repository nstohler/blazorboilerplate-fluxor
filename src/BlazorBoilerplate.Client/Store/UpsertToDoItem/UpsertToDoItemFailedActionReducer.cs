using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.UpsertToDoItem
{
    public class UpsertToDoItemFailedActionReducer : Reducer<UpsertToDoItemState, UpsertToDoItemFailedAction>
    {
        public override UpsertToDoItemState Reduce(UpsertToDoItemState state, UpsertToDoItemFailedAction action)
        {
            return new UpsertToDoItemState(false, null, action.ErrorMessage);
        }
    }
}