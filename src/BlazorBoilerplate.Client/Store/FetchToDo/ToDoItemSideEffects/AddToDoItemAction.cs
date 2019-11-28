using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.FetchToDo.ToDoItemSideEffects
{
    public class AddToDoItemAction
    {
        public TodoDto TodoDto { get; }

        public AddToDoItemAction(TodoDto todoDto)
        {
            TodoDto = todoDto;
        }
    }
}
