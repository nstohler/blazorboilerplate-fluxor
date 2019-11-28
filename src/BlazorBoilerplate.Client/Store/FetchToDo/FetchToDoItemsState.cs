using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.FetchToDo
{
    public interface IFetchToDoItemsState
    {
        bool                   IsLoading                { get; }
        string                 ErrorMessage             { get; }
        ImmutableList<TodoDto> ToDoItems                { get; }
        DateTime?              LastSuccessFetchDateTime { get; }
    }

    public class FetchToDoItemsState : IFetchToDoItemsState
    {
        public bool                   IsLoading                { get; set; }
        public string                 ErrorMessage             { get; set; }
        public ImmutableList<TodoDto> ToDoItems                { get; set; }
        public DateTime?              LastSuccessFetchDateTime { get; set; }

        public FetchToDoItemsState(bool isLoading, string errorMessage, ImmutableList<TodoDto> toDoItems,
            DateTime? lastSuccessFetchDateTime)
        {
            IsLoading                = isLoading;
            ErrorMessage             = errorMessage;
            ToDoItems                = toDoItems;
            LastSuccessFetchDateTime = lastSuccessFetchDateTime;
        }
    }

    internal static class FetchToDoItemsStateFactory
    {
        public static FetchToDoItemsState CreateNew()
        {
            return new FetchToDoItemsState(
                false,
                null,
                null,
                null
            );
        }
    }
}