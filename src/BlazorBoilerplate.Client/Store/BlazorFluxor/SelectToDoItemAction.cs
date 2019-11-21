using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Client.Store.BlazorFluxor
{
    public class SelectToDoItemAction
    {
        public long? ToDoId { get; private set; }

        public SelectToDoItemAction(long? doId)
        {
            ToDoId = doId;
        }
    }
}
