using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.ToDoItem.CreateNew
{
    public class CreateNewReducers
    {
        [ReducerMethod]
        public IToDoItemState Reduce(IToDoItemState state, CreateNewToDoItemAction action)
        {
            //var newState = (ToDoItemState)FastDeepCloner.DeepCloner.Clone(state);
            var newState = ToDoItemStateFactory.CreateNew();

            // only changes need to be done here now
            newState.IsProcessing      = true;
            newState.TodoDto           = action.AddTodo;
            newState.ToDoItemOperation = ToDoItemOperation.Add;

            return newState;
        }

        [ReducerMethod]
        public IToDoItemState Reduce(IToDoItemState state, CreateNewToDoItemResultAction action)
        {
            var newState = ToDoItemStateFactory.CreateNew();
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