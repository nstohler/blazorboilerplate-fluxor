using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.BlazorFluxor
{
    public class SelectEditToDoAction
    {
        public TodoDto TodoDto { get; private set; }

        public SelectEditToDoAction(TodoDto todoDto)
        {
            TodoDto = todoDto;
        }
    }
}
