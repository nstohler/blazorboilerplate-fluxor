using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.FetchToDo.ToDoItemSideEffects
{
    public class UpdateToDoItemAction
    {
        public TodoDto TodoDto { get; }

        public UpdateToDoItemAction(TodoDto todoDto)
        {
            TodoDto = todoDto;
        }
    }
}
