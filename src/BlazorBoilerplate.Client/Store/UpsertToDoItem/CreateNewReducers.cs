using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;
using BlazorBoilerplate.Client.Store.UpsertToDoItem.CreateNew;

namespace BlazorBoilerplate.Client.Store.UpsertToDoItem
{
    public class CreateNewReducers
    {
        [ReducerMethod]
        public IUpsertToDoItemState Reduce(IUpsertToDoItemState state, CreateNewToDoItemAction action)
        {
            //var newState = (UpsertToDoItemState)FastDeepCloner.DeepCloner.Clone(state);
            var newState = UpsertToDoItemState.CreateNew();

            // only changes need to be done here now
            newState.IsProcessing      = true;
            newState.TodoDto           = action.AddTodo;
            newState.ToDoItemOperation = ToDoItemOperation.Add;

            return newState;

            //return new UpsertToDoItemState(
            //    true,
            //    action.AddTodo,
            //    null);
        }

        [ReducerMethod]
        public IUpsertToDoItemState Reduce(IUpsertToDoItemState state, CreateNewToDoItemFailedAction action)
        {
            //return new UpsertToDoItemState(false, null, action.ErrorMessage);
            //var newState = (UpsertToDoItemState)FastDeepCloner.DeepCloner.Clone(state);
            var newState = UpsertToDoItemState.CreateNew();

            // only changes need to be done here now
            newState.ErrorMessage      = action.ErrorMessage;

            return newState;
        }

        [ReducerMethod]
        public IUpsertToDoItemState Reduce(IUpsertToDoItemState state, CreateNewToDoItemSuccessAction action)
        {
            //return new UpsertToDoItemState(false, action.Todo, null);
            //var newState = (UpsertToDoItemState)FastDeepCloner.DeepCloner.Clone(state);
            var newState = UpsertToDoItemState.CreateNew();

            // only changes need to be done here now
            newState.TodoDto           = action.Todo;
            
            return newState;
        }
    }
}
