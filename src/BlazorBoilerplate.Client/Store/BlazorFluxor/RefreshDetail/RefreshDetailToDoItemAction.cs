namespace BlazorBoilerplate.Client.Store.BlazorFluxor.RefreshDetail
{
    public class RefreshDetailToDoItemAction
    {
        public long? ToDoId { get; private set; }

        public RefreshDetailToDoItemAction(long? toDoId)
        {
            ToDoId = toDoId;
        }
    }
}
