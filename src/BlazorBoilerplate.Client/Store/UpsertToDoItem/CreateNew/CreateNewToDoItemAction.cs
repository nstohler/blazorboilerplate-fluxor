﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorBoilerplate.Shared.Dto;

namespace BlazorBoilerplate.Client.Store.UpsertToDoItem.CreateNew
{
    public class CreateNewToDoItemAction
    {
        public TodoDto AddTodo { get; }

        public CreateNewToDoItemAction(TodoDto addTodo)
        {
            AddTodo = addTodo;
        }
    }
}
