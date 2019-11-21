using System.Threading.Tasks;
using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.BlazorFluxor
{
    public class RefreshDetailToDoItemEffect : Effect<RefreshDetailToDoItemAction>
    {
        private readonly IState<BlazorFluxorState> _blazorFluxorState;

        public RefreshDetailToDoItemEffect(IState<BlazorFluxorState> blazorFluxorState)
        {
            _blazorFluxorState = blazorFluxorState;
        }

        protected override Task HandleAsync(RefreshDetailToDoItemAction action, IDispatcher dispatcher)
        {
            // only refresh if the item was selected before!
            if (_blazorFluxorState.Value.DetailToDoId == action.ToDoId)
            {
                dispatcher.Dispatch(new DetailByIdToDoItemAction(action.ToDoId));
            }
            return Task.CompletedTask;
        }
    }
}