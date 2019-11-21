using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.FetchToDo
{
    public class UpdateToDoItemActionReducer : Reducer<FetchToDoItemsState, UpdateToDoItemAction>
    {
        public override FetchToDoItemsState Reduce(FetchToDoItemsState state, UpdateToDoItemAction action)
        {
            if (state.ToDoItems == null)
            {
                return state;
            }

            var toDoItems = state.ToDoItems.ToList();
            var index = toDoItems.FindIndex(x => x.Id == action.TodoDto.Id);

            if (action.TodoDto.Id > 0 && index > -1)
            {
                toDoItems[index] = action.TodoDto;
            }
            else
            {
                toDoItems.Add(action.TodoDto);
            }
            
            return new FetchToDoItemsState(false, null, toDoItems.ToImmutableList());
        }
    }
}
