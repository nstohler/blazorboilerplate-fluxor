using System;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Fluxor;
using BlazorBoilerplate.Client.Store.BlazorFluxor.EditByRef;
using BlazorBoilerplate.Client.Store.FetchToDo;

namespace BlazorBoilerplate.Client.Store.BlazorFluxor.EditById
{
    public class EditByIdToDoItemEffect : Effect<EditByIdToDoItemAction>
    {
        private readonly IState<FetchToDoItemsState> _fetchToDoItemsState;

        public EditByIdToDoItemEffect(IState<FetchToDoItemsState> fetchToDoItemsState)
        {
            _fetchToDoItemsState = fetchToDoItemsState;
        }

        protected override Task HandleAsync(EditByIdToDoItemAction action, IDispatcher dispatcher)
        {
            try
            {
                // check if loaded (possible)?
                var item = _fetchToDoItemsState.Value.ToDoItems.SingleOrDefault(x => x.Id == action.ToDoId);

                //dispatcher.Dispatch(new SelectToDoDetailAction(item));

                // create a copy for editing so the original doesnt change!
                // alt: use https://github.com/AlenToma/FastDeepCloner
                //var editCopy = new TodoDto();

                //if (item != null)
                //{
                //    editCopy = new TodoDto()
                //    {
                //        Id          = item.Id,
                //        IsCompleted = item.IsCompleted,
                //        Title       = item.Title
                //    };
                //}

                var clonedItem = FastDeepCloner.DeepCloner.Clone(item);

                //dispatcher.Dispatch(new EditByRefToDoEditAction(editCopy));
                dispatcher.Dispatch(new EditByRefToDoEditAction(clonedItem));

                return Task.CompletedTask;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}