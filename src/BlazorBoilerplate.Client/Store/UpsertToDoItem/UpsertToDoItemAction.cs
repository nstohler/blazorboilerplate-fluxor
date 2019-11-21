using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.FetchToDo.UpsertToDoItem
{
    public class UpsertToDoItemAction
    {
        public TodoDto TodoDto { get; private set; }

        public UpsertToDoItemAction(TodoDto todoDto)
        {
            TodoDto = todoDto;
        }
    }
}
