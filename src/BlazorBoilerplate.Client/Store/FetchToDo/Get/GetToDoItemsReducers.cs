using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;

namespace BlazorBoilerplate.Client.Store.FetchToDo.Get
{
    public class GetToDoItemsReducers
    {
        [ReducerMethod]
        public IFetchToDoItemsState Reduce(IFetchToDoItemsState state, GetToDoItemsAction action)
        {
            var newState = FetchToDoItemsStateFactory.CreateNew();

            newState.IsLoading = true;

            if (state.LastSuccessFetchDateTime.HasValue)
            {
                newState.ToDoItems = state.ToDoItems; // keep old items while loading new ones
            }

            return newState;
        }

        [ReducerMethod]
        public IFetchToDoItemsState Reduce(IFetchToDoItemsState state, GetToDoItemsResultAction action)
        {
            Console.WriteLine($"GetToDoItemsReducers:GetToDoItemsResultAction");

            var newState = FetchToDoItemsStateFactory.CreateNew();
            newState.LastSuccessFetchDateTime = state.LastSuccessFetchDateTime;

            if (action.IsSuccess)
            {
                Console.WriteLine($"GetToDoItemsReducers:GetToDoItemsResultAction success");
                newState.ToDoItems = action.ToToItems.ToImmutableList();
                newState.LastSuccessFetchDateTime = DateTime.UtcNow;
            }
            else
            {
                Console.WriteLine($"GetToDoItemsReducers:GetToDoItemsResultAction failed");
                newState.ErrorMessage = action.ErrorMessage;
                
                if (state.LastSuccessFetchDateTime.HasValue)
                {
                    newState.ToDoItems = state.ToDoItems; // keep old items if there was an error loading new ones
                }
            }

            return newState;
        }
    }
}
