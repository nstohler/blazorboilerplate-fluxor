using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.UpsertToDoItem.Delete
{
    public class DeleteToDoItemReducers
    {
        [ReducerMethod]
        public IUpsertToDoItemState Reduce(IUpsertToDoItemState state, DeleteToDoItemAction action)
        {
            var newState = UpsertToDoItemState.CreateNew();

            // only changes need to be done here now
            newState.IsProcessing      = true;
            newState.TodoDto           = action.TodoDto;
            newState.ToDoItemOperation = ToDoItemOperation.Delete;

            return newState;
        }

        [ReducerMethod]
        public IUpsertToDoItemState Reduce(IUpsertToDoItemState state, DeleteToDoItemResultAction action)
        {
            var newState = UpsertToDoItemState.CreateNew();
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