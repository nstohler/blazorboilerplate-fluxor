using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.BlazorFluxor
{
    public class RefreshDetailToDoItemAction
    {
        public long? ToDoId { get; private set; }

        public RefreshDetailToDoItemAction(long? toDoId)
        {
            ToDoId = toDoId;
        }
    }

    //public class RefreshDetailToDoItemActionReducer : Reducer<BlazorFluxorState, RefreshDetailToDoItemAction>
    //{
    //    public override BlazorFluxorState Reduce(BlazorFluxorState state, RefreshDetailToDoItemAction action)
    //    {
    //        if (state.DetailToDoId == action.ToDoId)
    //        {
    //            this.
    //        }

    //        return state;
    //    }
    //}

    public class RefreshDetailToDoItemEffect : Effect<RefreshDetailToDoItemAction>
    {
        private readonly IState<BlazorFluxorState> _blazorFluxorState;

        public RefreshDetailToDoItemEffect(IState<BlazorFluxorState> blazorFluxorState)
        {
            _blazorFluxorState = blazorFluxorState;
        }

        protected override Task HandleAsync(RefreshDetailToDoItemAction action, IDispatcher dispatcher)
        {
            if (_blazorFluxorState.Value.DetailToDoId == action.ToDoId)
            {
                dispatcher.Dispatch(new DetailByIdToDoItemAction(action.ToDoId));
            }
            return Task.CompletedTask;
        }
    }
}
