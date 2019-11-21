using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;
using BlazorBoilerplate.Client.Store.FetchToDo;
using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.BlazorFluxor
{
    public class SelectToDoItemEffect : Effect<SelectToDoItemAction>
    {
        private readonly IState<FetchToDoItemsState> _fetchToDoItemsState;

        public SelectToDoItemEffect(IState<FetchToDoItemsState> fetchToDoItemsState)
        {
            _fetchToDoItemsState = fetchToDoItemsState;
        }

        protected override async Task HandleAsync(SelectToDoItemAction action, IDispatcher dispatcher)
        {
            try
            {
                // check if loaded (possible)?
                var item = _fetchToDoItemsState.Value.ToDoItems.SingleOrDefault(x => x.Id == action.ToDoId);

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

                //dispatcher.Dispatch(new SelectEditToDoAction(editCopy));
                dispatcher.Dispatch(new SelectEditToDoAction(clonedItem));

                await Task.Delay(0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
