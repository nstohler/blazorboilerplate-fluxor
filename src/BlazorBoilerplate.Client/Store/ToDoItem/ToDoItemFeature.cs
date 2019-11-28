using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.ToDoItem
{
    public class ToDoItemFeature : Feature<IToDoItemState>
    {
        public override string GetName() => "ToDoItem";

        //protected override IToDoItemState GetInitialState() => new ToDoItemState(false, null, null, ToDoItemOperation.None);
        protected override IToDoItemState GetInitialState() => ToDoItemStateFactory.CreateNew();
    }
}