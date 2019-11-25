using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.UpsertToDoItem.CreateNew
{
    //public class CreateNewToDoItemActionReducer : Reducer<IUpsertToDoItemState, CreateNewToDoItemAction>
    //{
    //    public override IUpsertToDoItemState Reduce(IUpsertToDoItemState state, CreateNewToDoItemAction action)
    //    {
    //        var newState = (UpsertToDoItemState)FastDeepCloner.DeepCloner.Clone(state);

    //        // only changes need to be done here now
    //        newState.IsProcessing = true;
    //        newState.TodoDto = action.AddTodo;
    //        newState.ErrorMessage = null;
    //        newState.ToDoItemOperation = ToDoItemOperation.Add;

    //        return newState;

    //        //return new UpsertToDoItemState(
    //        //    true,
    //        //    action.AddTodo,
    //        //    null);
    //    }
    //}
}
