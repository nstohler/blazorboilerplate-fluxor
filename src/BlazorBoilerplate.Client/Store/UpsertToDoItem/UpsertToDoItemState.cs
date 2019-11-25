using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.UpsertToDoItem
{
    public class UpsertToDoItemState : IUpsertToDoItemState
    {
        // allow setters / use interface?

        // TODO: rename to isProcessing?
        public bool              IsProcessing      { get; set; }
        public TodoDto           TodoDto           { get; set; }
        public string            ErrorMessage      { get; set; }
        public ToDoItemOperation ToDoItemOperation { get; set; }

        // TODO: add operation enum (create | update | delete)

        public UpsertToDoItemState(bool isProcessing, TodoDto todoDto, string errorMessage,
            ToDoItemOperation toDoItemOperation)
        {
            IsProcessing      = isProcessing;
            TodoDto           = todoDto;
            ErrorMessage      = errorMessage;
            ToDoItemOperation = toDoItemOperation;
        }

        public static UpsertToDoItemState CreateNew()
        {
            return new UpsertToDoItemState(false, null, null, ToDoItemOperation.None);
        }
    }

    public interface IUpsertToDoItemState
    {
        bool    IsProcessing { get; }
        TodoDto TodoDto      { get; }
        string  ErrorMessage { get; }
    }

    public enum ToDoItemOperation
    {
        None,
        Add,
        Edit,
        Delete
    }
}