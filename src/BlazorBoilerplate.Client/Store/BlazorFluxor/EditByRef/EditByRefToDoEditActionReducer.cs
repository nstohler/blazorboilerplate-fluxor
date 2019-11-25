using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.BlazorFluxor.EditByRef
{
    public class EditByRefToDoEditActionReducer : Reducer<IBlazorFluxorState, EditByRefToDoEditAction>
    {
        public override IBlazorFluxorState Reduce(IBlazorFluxorState state, EditByRefToDoEditAction action)
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
