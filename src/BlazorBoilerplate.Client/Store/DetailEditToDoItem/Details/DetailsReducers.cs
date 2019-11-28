using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.DetailEditToDoItem.Details
{
    public class DetailsReducers
    {
        [ReducerMethod]
        public IDetailEditToDoItemState Reduce(IDetailEditToDoItemState state, DetailByIdToDoItemAction action)
        {
            var newState = BlazorFluxorStateFactory.Clone(state);

            newState.DetailToDoId  = action.ToDoItemId;
            newState.DetailToDoDto = null;

            return newState;
        }

        [ReducerMethod]
        public IDetailEditToDoItemState Reduce(IDetailEditToDoItemState state, DetailByRefToDoItemAction action)
        {
            var newState = BlazorFluxorStateFactory.Clone(state);

            newState.DetailToDoDto = action.ToDoItem;

            return newState;
        }
    }
}
