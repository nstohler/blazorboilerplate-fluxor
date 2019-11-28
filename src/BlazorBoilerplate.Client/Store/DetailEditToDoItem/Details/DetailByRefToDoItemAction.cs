using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.DetailEditToDoItem.Details
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