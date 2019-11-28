using System;
using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.ToDoItem
{
    public class ToDoItemState : IToDoItemState
    {
        // allow setters / use interface?

        // TODO: rename to isProcessing?
        public bool              IsProcessing          { get; set; }
        public TodoDto           TodoDto               { get; set; }
        public string            ErrorMessage          { get; set; }
        public ToDoItemOperation ToDoItemOperation     { get; set; }
        public DateTime          LastOperationDateTime { get; set; }

        // TODO: add operation enum (create | update | delete)

        public ToDoItemState(bool isProcessing, TodoDto todoDto, string errorMessage,
            ToDoItemOperation toDoItemOperation, DateTime lastOperationDateTime)
        {
            IsProcessing          = isProcessing;
            TodoDto               = todoDto;
            ErrorMessage          = errorMessage;
            ToDoItemOperation     = toDoItemOperation;
            LastOperationDateTime = lastOperationDateTime;
        }

        public static ToDoItemState CreateNew()
        {
            return new ToDoItemState(false, null, null, ToDoItemOperation.None, DateTime.UtcNow);
        }
    }

    public interface IToDoItemState
    {
        bool              IsProcessing          { get; }
        TodoDto           TodoDto               { get; }
        string            ErrorMessage          { get; }
        ToDoItemOperation ToDoItemOperation     { get; }
        DateTime          LastOperationDateTime { get; }
    }

    public enum ToDoItemOperation
    {
        None,
        Add,
        Update,
        Delete
    }
}