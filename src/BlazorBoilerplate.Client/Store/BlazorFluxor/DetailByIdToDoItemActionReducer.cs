using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.BlazorFluxor
{
    public class DetailByIdToDoItemActionReducer : Reducer<BlazorFluxorState, DetailByIdToDoItemAction>
    {
        public override BlazorFluxorState Reduce(BlazorFluxorState state, DetailByIdToDoItemAction action)
        {
            return new BlazorFluxorState(action.ToDoItemId, 
                null, 
                state.EditToDoId,
                state.EditToDoDto
                );
        }
    }
}
