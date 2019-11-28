using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.ToDoItem.Delete
{
    public class DeleteToDoItemReducers
    {
        [ReducerMethod]
        public IToDoItemState Reduce(IToDoItemState state, DeleteToDoItemAction action)
        {
            var newState = ToDoItemStateFactory.CreateNew();

            // only changes need to be done here now
            newState.IsProcessing      = true;
            newState.TodoDto           = action.TodoDto;
            newState.ToDoItemOperation = ToDoItemOperation.Delete;

            return newState;
        }

        [ReducerMethod]
        public IToDoItemState Reduce(IToDoItemState state, DeleteToDoItemResultAction action)
        {
            var newState = ToDoItemStateFactory.CreateNew();
            newState.ToDoItemOperation = ToDoItemOperation.Delete;

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