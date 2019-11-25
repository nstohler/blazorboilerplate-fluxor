using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.UpsertToDoItem.Update
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