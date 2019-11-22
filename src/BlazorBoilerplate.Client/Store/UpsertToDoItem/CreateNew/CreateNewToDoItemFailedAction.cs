using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Client.Store.UpsertToDoItem.CreateNew
{
    public class CreateNewToDoItemFailedAction
    {
        public string ErrorMessage { get; }

        public CreateNewToDoItemFailedAction(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
