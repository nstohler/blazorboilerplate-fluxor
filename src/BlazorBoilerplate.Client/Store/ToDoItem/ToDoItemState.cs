using System;
using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.ToDoItem
{
    public interface IToDoItemState
    {
        bool              IsProcessing          { get; }
        TodoDto           TodoDto               { get; }
        string            ErrorMessage          { get; }
        ToDoItemOperation ToDoItemOperation     { get; }
        DateTime          LastOperationDateTime { get; }
    }

    public class ToDoItemState : IToDoItemState
    {
        public bool              IsProcessing          { get; set; }
        public TodoDto           TodoDto               { get; set; }
        public string            ErrorMessage          { get; set; }
        public ToDoItemOperation ToDoItemOperation     { get; set; }
        public DateTime          LastOperationDateTime { get; set; }

        public ToDoItemState(bool isProcessing, TodoDto todoDto, string errorMessage,
            ToDoItemOperation toDoItemOperation, DateTime lastOperationDateTime)
        {
            IsProcessing          = isProcessing;
            TodoDto               = todoDto;
            ErrorMessage          = errorMessage;
            ToDoItemOperation     = toDoItemOperation;
            LastOperationDateTime = lastOperationDateTime;
        }
    }

    internal static class ToDoItemStateFactory
    {
        public static ToDoItemState CreateNew()
        {
            return new ToDoItemState(false, null, null, ToDoItemOperation.None, DateTime.UtcNow);
        }
    }

    public enum ToDoItemOperation
    {
        None,
        Add,
        Update,
        Delete
    }
}