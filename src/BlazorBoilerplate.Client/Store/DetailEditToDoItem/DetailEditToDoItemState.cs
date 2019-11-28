using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.DetailEditToDoItem
{
    public interface IDetailEditToDoItemState
    {
        long?   DetailToDoId  { get; }
        TodoDto DetailToDoDto { get; }
        long?   EditToDoId    { get; }
        TodoDto EditToDoDto   { get; }
    }

    public class DetailEditToDoItemState : IDetailEditToDoItemState
    {
        public long?   DetailToDoId  { get; set; }
        public TodoDto DetailToDoDto { get; set; }

        public long?   EditToDoId  { get; set; }
        public TodoDto EditToDoDto { get; set; }

        public DetailEditToDoItemState(long? detailToDoId, TodoDto detailToDoDto, long? editToDoId, TodoDto editToDoDto)
        {
            DetailToDoDto = detailToDoDto;
            DetailToDoId  = detailToDoId;

            EditToDoId  = editToDoId;
            EditToDoDto = editToDoDto;
        }
    }

    public static class BlazorFluxorStateFactory
    {
        public static DetailEditToDoItemState CreateNew()
        {
            return new DetailEditToDoItemState(
                null,
                null,
                null,
                null
            );
        }

        public static DetailEditToDoItemState Clone(IDetailEditToDoItemState source)
        {
            return (DetailEditToDoItemState)FastDeepCloner.DeepCloner.Clone(source);
        }
    }
}