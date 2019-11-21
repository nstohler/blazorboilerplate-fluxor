using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.FetchToDo
{
    public class RemoveToDoItemActionReducer : Reducer<FetchToDoItemsState, RemoveToDoItemAction>
    {
        public override FetchToDoItemsState Reduce(FetchToDoItemsState state, RemoveToDoItemAction action)
        {
            var toDoItems = state.ToDoItems.Where(x => x.Id != action.TodoDto.Id).ToList();
            
            return new FetchToDoItemsState(
                false, 
                null, 
                toDoItems.ToImmutableList()
                );
        }
    }
}
