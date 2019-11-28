using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.FetchToDo.Get
{
    public class GetToDoItemsResultAction
    {
        public GetToDoItemsResultAction(List<TodoDto> toItems, bool isSuccess, string errorMessage)
        {
            ToToItems = toItems;
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
        }

        public List<TodoDto> ToToItems    { get; private set; }
        public bool          IsSuccess    { get; private set; }
        public string        ErrorMessage { get; private set; }
    }
}