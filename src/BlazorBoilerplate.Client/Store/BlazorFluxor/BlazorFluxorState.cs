using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.BlazorFluxor
{
    public class BlazorFluxorState : IBlazorFluxorState
    {
        public BlazorFluxorState(long? detailToDoId, TodoDto detailToDoDto, long? editToDoId, TodoDto editToDoDto)
        {
            DetailToDoDto = detailToDoDto;
            DetailToDoId = detailToDoId;

            EditToDoId = editToDoId;
            EditToDoDto = editToDoDto;
        }

        public long? DetailToDoId { get; private set; }
        public TodoDto DetailToDoDto { get; private set; }

        public long? EditToDoId { get; private set; }
        public TodoDto EditToDoDto { get; private set; }

        
    }

    public interface IBlazorFluxorState
    {
        long? DetailToDoId { get; }
        TodoDto DetailToDoDto { get; }
        long? EditToDoId { get; }
        TodoDto EditToDoDto { get; }
    }
}
