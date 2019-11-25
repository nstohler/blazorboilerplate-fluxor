using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.UpsertToDoItem.Delete
{
    public class DeleteToDoItemAction
    {
        public TodoDto TodoDto { get; private set; }

        public DeleteToDoItemAction(TodoDto todoDto)
        {
            TodoDto = todoDto;
        }
    }
}
