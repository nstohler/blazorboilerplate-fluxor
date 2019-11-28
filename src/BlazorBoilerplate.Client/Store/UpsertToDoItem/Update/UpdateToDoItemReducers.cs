using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;
using BlazorBoilerplate.Client.Store.UpsertToDoItem.Update;

namespace BlazorBoilerplate.Client.Store.UpsertToDoItem
{
    public class UpdateToDoItemReducers
    {
        [ReducerMethod]
        public IUpsertToDoItemState Reduce(IUpsertToDoItemState state, UpdateToDoItemAction action)
        {
            var newState = UpsertToDoItemState.CreateNew();

            // only changes need to be done here now
            newState.IsProcessing      = true;
            newState.TodoDto           = action.TodoDto;
            newState.ToDoItemOperation = ToDoItemOperation.Update;

            return newState;
        }

        [ReducerMethod]
        public IUpsertToDoItemState Reduce(IUpsertToDoItemState state, UpdateToDoItemResultAction action)
        {
            var newState = UpsertToDoItemState.CreateNew();
            newState.ToDoItemOperation = ToDoItemOperation.Update;

            if (action.IsSuccess)
            {
                newState.TodoDto = action.TodoDto;
            }
            else
            {
                newState.ErrorMessage = action.ErrorMessage;
            }

            return newState;
        }
    }
}