using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.UpsertToDoItem.CreateNew
{
    public class CreateNewToDoItemFailedReducer : Reducer<UpsertToDoItemState, CreateNewToDoItemFailedAction>
    {
        public override UpsertToDoItemState Reduce(UpsertToDoItemState state, CreateNewToDoItemFailedAction action)
        {
            return new UpsertToDoItemState(false, null, action.ErrorMessage);
        }
    }
}
