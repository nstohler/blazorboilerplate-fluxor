using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.BlazorFluxor
{
    public class EditByRefToDoEditActionReducer : Reducer<BlazorFluxorState, EditByRefToDoEditAction>
    {
        public override BlazorFluxorState Reduce(BlazorFluxorState state, EditByRefToDoEditAction action)
        {
            return new BlazorFluxorState(
                state.DetailToDoId,
                state.DetailToDoDto,
                state.EditToDoId,
                action.TodoDto
                );
        }
    }
}
