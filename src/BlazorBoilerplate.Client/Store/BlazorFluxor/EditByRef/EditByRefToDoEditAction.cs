using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.BlazorFluxor.EditByRef
{
    public class EditByRefToDoEditAction
    {
        public TodoDto TodoDto { get; private set; }

        public EditByRefToDoEditAction(TodoDto todoDto)
        {
            TodoDto = todoDto;
        }
    }
}
