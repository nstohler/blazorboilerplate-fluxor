using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlazorBoilerplate.Client.Store.BlazorFluxor
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
