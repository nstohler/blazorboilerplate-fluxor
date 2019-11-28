using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.UpsertToDoItem.CreateNew
{
    public class CreateNewToDoItemResultAction
    {
        public CreateNewToDoItemResultAction(TodoDto todo, bool isSuccess, string errorMessage)
        {
            Todo = todo;
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
        }

        public TodoDto Todo         { get; private set; }
        public bool    IsSuccess    { get; private set; }
        public string  ErrorMessage { get; private set; }
    }
}