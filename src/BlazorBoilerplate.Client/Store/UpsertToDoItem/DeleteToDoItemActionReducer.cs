using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blazor.Fluxor;
using BlazorBoilerplate.Shared.Dto;
using Microsoft.AspNetCore.Components;

namespace BlazorBoilerplate.Client.Store.UpsertToDoItem
{
    public class DeleteToDoItemActionReducer: Reducer<UpsertToDoItemState, DeleteToDoItemAction>
    {
        public override UpsertToDoItemState Reduce(UpsertToDoItemState state, DeleteToDoItemAction action)
        {
            return new UpsertToDoItemState(
                true, 
                action.TodoDto, 
                null);
        }
    }
}
