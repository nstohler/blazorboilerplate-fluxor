using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.ToDoItem.CreateNew
{
    public class CreateNewToDoItemAction
    {
        public TodoDto AddTodo { get; }

        public CreateNewToDoItemAction(TodoDto addTodo)
        {
            AddTodo = addTodo;
        }
    }
}
