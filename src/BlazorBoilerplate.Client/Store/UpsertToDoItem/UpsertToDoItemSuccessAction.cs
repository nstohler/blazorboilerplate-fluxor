using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.UpsertToDoItem
{
    public class UpsertToDoItemSuccessAction
    {
        public TodoDto TodoDto { get; }

        public UpsertToDoItemSuccessAction(TodoDto todoDto)
        {
            TodoDto = todoDto;
        }
    }
}