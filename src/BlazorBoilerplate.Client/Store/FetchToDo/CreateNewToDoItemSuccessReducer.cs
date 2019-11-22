using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;
using BlazorBoilerplate.Client.Store.UpsertToDoItem.CreateNew;
using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.FetchToDo
{
    public class CreateNewToDoItemSuccessReducer : Reducer<FetchToDoItemsState, CreateNewToDoItemSuccessAction>
    {
        public override FetchToDoItemsState Reduce(FetchToDoItemsState state, CreateNewToDoItemSuccessAction action)
        {
            if (state.ToDoItems == null)
            {
                var todos = new List<TodoDto>() { action.Todo };
                return new FetchToDoItemsState(false, null, todos.ToImmutableList());
            }

            // add at end
            var toDoItems = state.ToDoItems.Add(action.Todo);
            return new FetchToDoItemsState(false, null, toDoItems);
        }
    }
}
