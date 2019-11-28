using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.DetailEditToDoItem
{
    public class DetailEditToDoItemFeature : Feature<IDetailEditToDoItemState>
    {
        public override string GetName() => "DetailEditToDoItem";

        protected override IDetailEditToDoItemState GetInitialState() => BlazorFluxorStateFactory.CreateNew();
    }
}
