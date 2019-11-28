using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;
using BlazorBoilerplate.Client.Store.DetailEditToDoItem.Details;

namespace BlazorBoilerplate.Client.Store.DetailEditToDoItem.RefreshDetail
{
    public class RefreshDetailEffects
    {
        private readonly IState<IDetailEditToDoItemState> _blazorFluxorState;

        public RefreshDetailEffects(IState<IDetailEditToDoItemState> blazorFluxorState)
        {
            _blazorFluxorState = blazorFluxorState;
        }

        [EffectMethod]
        public Task HandleAsync(RefreshDetailToDoItemAction action, IDispatcher dispatcher)
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
