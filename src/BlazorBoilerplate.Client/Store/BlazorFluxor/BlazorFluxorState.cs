using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.BlazorFluxor
{
    public class BlazorFluxorState
    {
        public BlazorFluxorState(long? selectedToDoId, TodoDto editToDoDto)
        {
            SelectedToDoId = selectedToDoId;
            EditToDoDto = editToDoDto;
        }

        public long? SelectedToDoId { get; private set; }
        public TodoDto EditToDoDto { get; private set; }
    }
}
