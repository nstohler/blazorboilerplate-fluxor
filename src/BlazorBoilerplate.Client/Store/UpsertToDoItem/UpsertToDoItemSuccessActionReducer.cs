using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.UpsertToDoItem
{
    public class UpsertToDoItemSuccessActionReducer : Reducer<UpsertToDoItemState, UpsertToDoItemSuccessAction>
    {
        public override UpsertToDoItemState Reduce(UpsertToDoItemState state, UpsertToDoItemSuccessAction action)
        {
            return new UpsertToDoItemState(false, action.TodoDto, null);
        }
    }
}
