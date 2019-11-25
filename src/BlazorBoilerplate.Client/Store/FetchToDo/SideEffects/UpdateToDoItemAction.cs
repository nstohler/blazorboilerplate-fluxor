using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.FetchToDo.SideEffects
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
