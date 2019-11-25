using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.BlazorFluxor.EditByRef
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
