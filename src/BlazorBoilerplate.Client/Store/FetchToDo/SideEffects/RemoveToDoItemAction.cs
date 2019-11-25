using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.FetchToDo.SideEffects
{
    public class RemoveToDoItemAction
    {
        public TodoDto TodoDto { get; private set; }

        public RemoveToDoItemAction(TodoDto todoDto)
        {
            TodoDto = todoDto;
        }
    }
}
