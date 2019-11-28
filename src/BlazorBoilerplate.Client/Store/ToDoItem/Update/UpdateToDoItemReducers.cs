using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.ToDoItem.Update
{
    public class UpdateToDoItemReducers
    {
        [ReducerMethod]
        public IToDoItemState Reduce(IToDoItemState state, UpdateToDoItemAction action)
        {
            var newState = ToDoItemStateFactory.CreateNew();

            // only changes need to be done here now
            newState.IsProcessing      = true;
            newState.TodoDto           = action.TodoDto;
            newState.ToDoItemOperation = ToDoItemOperation.Update;

            return newState;
        }

        [ReducerMethod]
        public IToDoItemState Reduce(IToDoItemState state, UpdateToDoItemResultAction action)
        {
            var newState = ToDoItemStateFactory.CreateNew();
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