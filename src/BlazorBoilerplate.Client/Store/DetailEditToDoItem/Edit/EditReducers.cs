using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.DetailEditToDoItem.Edit
{
    public class EditReducers
    {
        [ReducerMethod]
        public IDetailEditToDoItemState Reduce(IDetailEditToDoItemState state, EditByIdToDoItemAction action)
        {
            var newState = BlazorFluxorStateFactory.Clone(state);

            newState.EditToDoId  = action.ToDoId;
            newState.EditToDoDto = null;

            return newState;
        }

        [ReducerMethod]
        public IDetailEditToDoItemState Reduce(IDetailEditToDoItemState state, EditByRefToDoEditAction action)
        {
            var newState = BlazorFluxorStateFactory.Clone(state);

            newState.EditToDoDto = action.TodoDto;

            return newState;
        }
    }
}
