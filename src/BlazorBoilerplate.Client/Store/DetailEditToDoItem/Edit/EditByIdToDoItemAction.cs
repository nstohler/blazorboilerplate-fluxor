using BlazorBoilerplate.Client.Store.Extensions;

namespace BlazorBoilerplate.Client.Store.DetailEditToDoItem.Edit
{
    public class EditByIdToDoItemAction : IActionWithSideEffect
    {
        public long? ToDoId { get; private set; }

        public EditByIdToDoItemAction(long? doId)
        {
            ToDoId = doId;
        }
    }
}
