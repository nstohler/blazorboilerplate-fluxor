using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Blazor.Fluxor;
using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.FetchToDo.ToDoItemSideEffects
{
    public class ToDoItemReducers
    {
        //[ReducerMethod]
        //public FetchToDoItemsState Reduce(FetchToDoItemsState state, ToDoItem.CreateNew.CreateNewToDoItemResultAction action)
        //{
        //    if (!action.IsSuccess)
        //    {
        //        return state;
        //    }

        //    var newState = FetchToDoItemsState.CreateNew();

        //    if (state.ToDoItems == null)
        //    {
        //        var todos = new List<TodoDto>() {action.Todo};

        //        newState.ToDoItems = todos.ToImmutableList();

        //        return newState;
        //    }

        //    // add at end
        //    var toDoItems = state.ToDoItems.Add(action.Todo);
        //    newState.ToDoItems = toDoItems.ToImmutableList();

        //    return newState;
        //}

        [ReducerMethod]
        public IFetchToDoItemsState Reduce(IFetchToDoItemsState state, AddToDoItemAction action)
        {
            var newState = FetchToDoItemsStateFactory.CreateNew();

            if (state.ToDoItems == null)
            {
                var todos = new List<TodoDto>() { action.TodoDto };

                newState.ToDoItems = todos.ToImmutableList();

                return newState;
            }

            // add at end
            var toDoItems = state.ToDoItems.Add(action.TodoDto);
            newState.ToDoItems = toDoItems.ToImmutableList();

            return newState;
        }

        [ReducerMethod]
        public IFetchToDoItemsState Reduce(IFetchToDoItemsState state, RemoveToDoItemAction action)
        {
            var toDoItems = state.ToDoItems.Where(x => x.Id != action.TodoDto.Id).ToList();

            var newState = FetchToDoItemsStateFactory.CreateNew();

            newState.ToDoItems = toDoItems.ToImmutableList();

            return newState;
        }

        [ReducerMethod]
        public IFetchToDoItemsState Reduce(IFetchToDoItemsState state, UpdateToDoItemAction action)
        {
            if (state.ToDoItems == null)
            {
                return state;
            }

            var toDoItems = state.ToDoItems.ToList();
            var index     = toDoItems.FindIndex(x => x.Id == action.TodoDto.Id);

            if (action.TodoDto.Id > 0 && index > -1)
            {
                toDoItems[index] = action.TodoDto;
            }
            else
            {
                toDoItems.Add(action.TodoDto);
            }

            var newState = FetchToDoItemsStateFactory.CreateNew();

            newState.ToDoItems = toDoItems.ToImmutableList();

            return newState;
        }
    }
}