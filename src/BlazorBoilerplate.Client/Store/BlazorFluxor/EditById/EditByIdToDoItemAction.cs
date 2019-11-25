namespace BlazorBoilerplate.Client.Store.BlazorFluxor.EditById
{
    public class EditByIdToDoItemAction
    {
        public long? ToDoId { get; private set; }

        public EditByIdToDoItemAction(long? doId)
        {
            ToDoId = doId;
        }
    }
}
