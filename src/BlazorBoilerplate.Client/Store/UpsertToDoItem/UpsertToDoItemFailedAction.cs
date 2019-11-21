﻿namespace BlazorBoilerplate.Client.Store.UpsertToDoItem
{
    public class UpsertToDoItemFailedAction
    {
        public string ErrorMessage { get; private set; }

        public UpsertToDoItemFailedAction(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}