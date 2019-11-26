using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;
using BlazorBoilerplate.Client.Store.UpsertToDoItem.Update;

namespace BlazorBoilerplate.Client.Store.UpsertToDoItem
{
    public class UpdateReducers
    {
        [ReducerMethod]
        public IUpsertToDoItemState Reduce(IUpsertToDoItemState state, UpsertToDoItemAction action)
        {
            //return new UpsertToDoItemState(true, null, null);
            //var newState = (UpsertToDoItemState)FastDeepCloner.DeepCloner.Clone(state);
            var newState = UpsertToDoItemState.CreateNew();

            // only changes need to be done here now
            newState.IsProcessing      = true;
            newState.TodoDto           = action.TodoDto;
            newState.ToDoItemOperation = ToDoItemOperation.Update;

            return newState;
        }

        [ReducerMethod]
        public IUpsertToDoItemState Reduce(IUpsertToDoItemState state, UpsertToDoItemFailedAction action)
        {
            //return new UpsertToDoItemState(false, null, action.ErrorMessage);
            var newState = UpsertToDoItemState.CreateNew();

            // only changes need to be done here now
            newState.ErrorMessage = action.ErrorMessage;

            return newState;
        }

        [ReducerMethod]
        public IUpsertToDoItemState Reduce(IUpsertToDoItemState state, UpsertToDoItemSuccessAction action)
        {
            // return new UpsertToDoItemState(false, action.TodoDto, null);
            var newState = UpsertToDoItemState.CreateNew();

            // only changes need to be done here now
            newState.TodoDto = action.TodoDto;

            return newState;
        }
    }
}