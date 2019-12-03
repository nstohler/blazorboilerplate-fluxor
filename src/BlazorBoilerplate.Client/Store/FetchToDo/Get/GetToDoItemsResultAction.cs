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
        public GetToDoItemsResultAction(ResultActionBase baseAction, List<TodoDto> toDoItems, bool isSuccess, string errorMessage)
        {
            base.ResultAction = baseAction.ResultAction;

            ToDoDoItems  = toDoItems;
            IsSuccess    = isSuccess;
            ErrorMessage = errorMessage;
        }

        public List<TodoDto> ToDoDoItems  { get; private set; }
        public bool          IsSuccess    { get; private set; }
        public string        ErrorMessage { get; private set; }
    }
}