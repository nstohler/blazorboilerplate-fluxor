using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.UpsertToDoItem.CreateNew
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
        }

        [ReducerMethod]
        public IUpsertToDoItemState Reduce(IUpsertToDoItemState state, CreateNewToDoItemResultAction action)
        {
            var newState = UpsertToDoItemState.CreateNew();
            newState.ToDoItemOperation = ToDoItemOperation.Add;

            if (action.IsSuccess)
            {
                newState.TodoDto = action.Todo;
            }
            else
            {
                newState.ErrorMessage = action.ErrorMessage;
            }

            return newState;
        }
    }
}