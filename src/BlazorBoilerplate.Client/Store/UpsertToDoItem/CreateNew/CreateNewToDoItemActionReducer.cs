using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.UpsertToDoItem.CreateNew
{
    public class CreateNewToDoItemActionReducer : Reducer<UpsertToDoItemState, CreateNewToDoItemAction>
    {
        public override UpsertToDoItemState Reduce(UpsertToDoItemState state, CreateNewToDoItemAction action)
        {
            return new UpsertToDoItemState(
                true,
                action.AddTodo,
                null);
        }
    }
}
