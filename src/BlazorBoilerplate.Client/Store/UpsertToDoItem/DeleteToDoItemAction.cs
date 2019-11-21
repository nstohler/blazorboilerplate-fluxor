using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.UpsertToDoItem
{
    public class DeleteToDoItemAction
    {
        public TodoDto TodoDto { get; private set; }

        public DeleteToDoItemAction(TodoDto todoDto)
        {
            TodoDto = todoDto;
        }
    }
}
