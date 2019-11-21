using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Client.Store.BlazorFluxor
{
    public class EditByIdToDoItemAction
    {
        public long? ToDoId { get; private set; }

        public EditByIdToDoItemAction(long? doId)
        {
            ToDoId = doId;
        }
    }
}
