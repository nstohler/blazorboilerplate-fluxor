using System.Collections.Generic;
using System.Collections.Immutable;
using Blazor.Fluxor;
using BlazorBoilerplate.Client.Store.ToDoItem.CreateNew;
using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.FetchToDo.SideEffects
{
    public class CreateNewToDoItemSuccessReducer : Reducer<FetchToDoItemsState, CreateNewToDoItemResultAction>
    {
        public override FetchToDoItemsState Reduce(FetchToDoItemsState state, CreateNewToDoItemResultAction action)
        {
            if (!action.IsSuccess)
            {
                return state;
            }

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
