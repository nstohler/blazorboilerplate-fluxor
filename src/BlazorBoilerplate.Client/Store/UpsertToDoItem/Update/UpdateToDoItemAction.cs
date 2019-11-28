using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.UpsertToDoItem.Update
{
    public class UpdateToDoItemAction
    {
        public TodoDto TodoDto { get; private set; }

        public UpdateToDoItemAction(TodoDto todoDto)
        {
            TodoDto = todoDto;
        }
    }
}
