using System.Collections.Generic;
using System.Collections.Immutable;
using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.FetchToDo
{
    public class FetchToDoItemsState
    {
        public bool                   IsLoading    { get; private set; }
        public string                 ErrorMessage { get; private set; }
        public ImmutableList<TodoDto> ToDoItems    { get; private set; }

        public FetchToDoItemsState(bool isLoading, string errorMessage, IEnumerable<TodoDto> toDoItems)
        {
            IsLoading    = isLoading;
            ErrorMessage = errorMessage;
            ToDoItems    = toDoItems?.ToImmutableList();
        }
    }
}