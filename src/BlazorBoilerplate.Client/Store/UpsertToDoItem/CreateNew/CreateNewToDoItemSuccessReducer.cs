using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.UpsertToDoItem.CreateNew
{
    public class CreateNewToDoItemSuccessReducer : Reducer<UpsertToDoItemState, CreateNewToDoItemSuccessAction>
    {
        public override UpsertToDoItemState Reduce(UpsertToDoItemState state, CreateNewToDoItemSuccessAction action)
        {
            return new UpsertToDoItemState(false, action.Todo, null);
        }
    }
}
