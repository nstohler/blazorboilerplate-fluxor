using System.Collections.Generic;
using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.FetchToDo.Get
{
    public class GetToDoItemsSuccessAction
    {
        public List<TodoDto> ToToItems { get; private set; }

        public GetToDoItemsSuccessAction(List<TodoDto> todos)
        {
            ToToItems = todos;
        }
    }
}