using BlazorBoilerplate.Client.Store.Extensions;

namespace BlazorBoilerplate.Client.Store.DetailEditToDoItem.RefreshDetail
{
    public class RefreshDetailToDoItemAction : IActionWithSideEffect
    {
        public long? ToDoId { get; private set; }

        public RefreshDetailToDoItemAction(long? toDoId)
        {
            ToDoId = toDoId;
        }
    }
}
