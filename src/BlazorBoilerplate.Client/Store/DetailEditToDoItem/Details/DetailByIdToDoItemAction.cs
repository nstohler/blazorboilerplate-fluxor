using BlazorBoilerplate.Client.Store.Extensions;

namespace BlazorBoilerplate.Client.Store.DetailEditToDoItem.Details
{
    public class DetailByIdToDoItemAction : IActionWithSideEffect
    {
        public long? ToDoItemId { get; private set; }

        public DetailByIdToDoItemAction(long? toDoItemId)
        {
            ToDoItemId = toDoItemId;
        }
    }
}
