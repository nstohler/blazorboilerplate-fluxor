using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.UpsertToDoItem.Delete
{
    public class DeleteToDoItemSuccessAction
    {
        public TodoDto TodoDto { get; private set; }

        public DeleteToDoItemSuccessAction(TodoDto todoDto)
        {
            TodoDto = todoDto;
        }
    }
}