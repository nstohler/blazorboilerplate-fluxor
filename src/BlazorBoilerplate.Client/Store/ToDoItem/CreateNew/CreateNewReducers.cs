using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.ToDoItem.CreateNew
{
    public class CreateNewReducers
    {
        [ReducerMethod]
        public IToDoItemState Reduce(IToDoItemState state, CreateNewToDoItemAction action)
        {
            //var newState = (ToDoItemState)FastDeepCloner.DeepCloner.Clone(state);
            var newState = ToDoItemState.CreateNew();

            // only changes need to be done here now
            newState.IsProcessing      = true;
            newState.TodoDto           = action.AddTodo;
            newState.ToDoItemOperation = ToDoItemOperation.Add;

            return newState;
        }

        [ReducerMethod]
        public IToDoItemState Reduce(IToDoItemState state, CreateNewToDoItemResultAction action)
        {
            var newState = ToDoItemState.CreateNew();
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