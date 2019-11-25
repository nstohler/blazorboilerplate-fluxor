using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;
using BlazorBoilerplate.Client.Store.UpsertToDoItem.Delete;

namespace BlazorBoilerplate.Client.Store.UpsertToDoItem
{
    public class DeleteReducers
    {
        [ReducerMethod]
        public IUpsertToDoItemState Reduce(IUpsertToDoItemState state, DeleteToDoItemAction action)
        {
            //var newState = (UpsertToDoItemState)FastDeepCloner.DeepCloner.Clone(state);
            var newState = UpsertToDoItemState.CreateNew();

            // only changes need to be done here now
            newState.IsProcessing      = true;
            newState.TodoDto           = action.TodoDto;
            newState.ToDoItemOperation = ToDoItemOperation.Delete;

            return newState;
        }

        [ReducerMethod]
        public IUpsertToDoItemState Reduce(IUpsertToDoItemState state, DeleteToDoItemFailedAction action)
        {
            //var newState = (UpsertToDoItemState)FastDeepCloner.DeepCloner.Clone(state);
            var newState = UpsertToDoItemState.CreateNew();

            // only changes need to be done here now
            newState.ErrorMessage      = action.ErrorMessage;

            return newState;
        }

        [ReducerMethod]
        public IUpsertToDoItemState Reduce(IUpsertToDoItemState state, DeleteToDoItemSuccessAction action)
        {
            var newState = UpsertToDoItemState.CreateNew();
            return newState;
        }
    }
}
