using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.FetchToDo
{
    public class RemoveToDoItemAction
    {
        public TodoDto TodoDto { get; private set; }

        public RemoveToDoItemAction(TodoDto todoDto)
        {
            TodoDto = todoDto;
        }
    }
}
