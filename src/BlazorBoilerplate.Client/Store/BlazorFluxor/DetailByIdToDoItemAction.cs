using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Client.Store.BlazorFluxor
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
