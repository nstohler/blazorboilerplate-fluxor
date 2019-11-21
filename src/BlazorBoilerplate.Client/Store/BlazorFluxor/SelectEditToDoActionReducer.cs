using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.BlazorFluxor
{
    public class SelectEditToDoActionReducer : Reducer<BlazorFluxorState, SelectEditToDoAction>
    {
        public override BlazorFluxorState Reduce(BlazorFluxorState state, SelectEditToDoAction action)
        {
            return new BlazorFluxorState(
                state.SelectedToDoId,
                action.TodoDto
                );
        }
    }
}
