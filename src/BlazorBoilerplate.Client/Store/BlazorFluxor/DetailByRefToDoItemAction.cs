using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.BlazorFluxor
{
    public class DetailByRefToDoItemAction
    {
        public TodoDto ToDoItem { get; }

        public DetailByRefToDoItemAction(TodoDto toDoItem)
        {
            ToDoItem = toDoItem;
        }
    }
}