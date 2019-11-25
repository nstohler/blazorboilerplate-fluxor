using System.Threading.Tasks;
using Blazor.Fluxor;
using BlazorBoilerplate.Client.Store.BlazorFluxor.DetailById;

namespace BlazorBoilerplate.Client.Store.BlazorFluxor.RefreshDetail
{
    public class RefreshDetailToDoItemEffect : Effect<RefreshDetailToDoItemAction>
    {
        private readonly IState<IBlazorFluxorState> _blazorFluxorState;

        public RefreshDetailToDoItemEffect(IState<IBlazorFluxorState> blazorFluxorState)
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