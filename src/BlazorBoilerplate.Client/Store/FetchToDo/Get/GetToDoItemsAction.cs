using System;
using BlazorBoilerplate.Client.Store.Extensions;

namespace BlazorBoilerplate.Client.Store.FetchToDo.Get
{
    public class GetToDoItemsAction : ResultActionBase, IActionWithSideEffect
    {
        public GetToDoItemsAction(Action<IResultAction> resultAction) : base(resultAction)
        {
        }
    }
}