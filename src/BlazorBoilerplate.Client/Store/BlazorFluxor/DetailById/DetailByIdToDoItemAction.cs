namespace BlazorBoilerplate.Client.Store.BlazorFluxor.DetailById
{
    public class DetailByIdToDoItemAction
    {
        public long? ToDoItemId { get; private set; }

        public DetailByIdToDoItemAction(long? toDoItemId)
        {
            ToDoItemId = toDoItemId;
        }
    }
}
