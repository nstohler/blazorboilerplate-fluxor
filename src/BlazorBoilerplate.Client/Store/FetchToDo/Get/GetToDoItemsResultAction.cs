using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorBoilerplate.Client.Store.Extensions;
using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.FetchToDo.Get
{
    public class GetToDoItemsResultAction : ResultActionBase
    {
        public GetToDoItemsResultAction(ResultActionBase baseAction, List<TodoDto> toDoItems, bool isSuccess,
            string errorMessage)
            : base(baseAction.ResultAction)
        {
            
            // base.ResultAction = baseAction.ResultAction;

            //ToDoDoItems       = toDoItems;
            //base.Data         = toDoItems;
            //base.IsSuccess    = isSuccess;
            //base.ErrorMessage = errorMessage;

            ToDoDoItems  = toDoItems;
            IsSuccess    = isSuccess;
            ErrorMessage = errorMessage;
        }

        // public List<TodoDto> ToDoDoItems => (List<TodoDto>) base.Data;

        public List<TodoDto> ToDoDoItems  { get; private set; }
        public bool          IsSuccess    { get; private set; }
        public string        ErrorMessage { get; private set; }
    }
}