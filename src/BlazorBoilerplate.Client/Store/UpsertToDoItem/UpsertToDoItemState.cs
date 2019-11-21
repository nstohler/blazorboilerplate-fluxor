using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.UpsertToDoItem
{
    public class UpsertToDoItemState
    {
        public bool    IsUpdating   { get; private set; }
        public TodoDto TodoDto      { get; private set; }
        public string  ErrorMessage { get; private set; }

        public UpsertToDoItemState(bool isUpdating, TodoDto todoDto, string errorMessage)
        {
            IsUpdating   = isUpdating;
            TodoDto      = todoDto;
            ErrorMessage = errorMessage;
        }
    }
}