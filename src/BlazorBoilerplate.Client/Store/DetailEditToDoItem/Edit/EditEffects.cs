using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;
using BlazorBoilerplate.Client.Store.FetchToDo;

namespace BlazorBoilerplate.Client.Store.DetailEditToDoItem.Edit
{
    public class EditEffects
    {
        private readonly IState<IFetchToDoItemsState> _fetchToDoItemsState;

        public EditEffects(IState<IFetchToDoItemsState> fetchToDoItemsState)
        {
            _fetchToDoItemsState = fetchToDoItemsState;
        }

        [EffectMethod]
        public Task HandleAsync(EditByIdToDoItemAction action, IDispatcher dispatcher)
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

                // clone it so the (unsaved) edits dont change the original item:
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
