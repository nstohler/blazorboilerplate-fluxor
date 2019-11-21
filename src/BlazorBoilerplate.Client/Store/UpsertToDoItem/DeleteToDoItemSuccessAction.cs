using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.UpsertToDoItem
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