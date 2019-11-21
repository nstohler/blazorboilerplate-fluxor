using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.FetchToDo
{
    public class UpdateToDoItemAction
    {
        public TodoDto TodoDto { get; }

        public UpdateToDoItemAction(TodoDto todoDto)
        {
            TodoDto = todoDto;
        }
    }
}
