using System;
using BlazorBoilerplate.Client.Store.Extensions;

namespace BlazorBoilerplate.Client.Store.FetchToDo.Get
{
    public class GetToDoItemsAction : ResultActionBase<GetToDoItemsResultAction>, IActionWithSideEffect
    {
        public GetToDoItemsAction(Action<GetToDoItemsResultAction> resultAction) : base(resultAction)
        {
        }
    }
}