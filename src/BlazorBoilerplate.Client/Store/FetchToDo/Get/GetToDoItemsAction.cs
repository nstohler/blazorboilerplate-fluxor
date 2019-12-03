using System;
using BlazorBoilerplate.Client.Store.Extensions;

namespace BlazorBoilerplate.Client.Store.FetchToDo.Get
{
    public class GetToDoItemsAction : ComponentNotificationActionBase<GetToDoItemsResultAction>, IActionWithSideEffect
    {
        public GetToDoItemsAction(Action<GetToDoItemsResultAction> notificationAction) 
            : base(notificationAction)
            //: base(Convert(resultAction))
        {
        }

        //public GetToDoItemsAction(Action<IResultAction> resultAction) : base(resultAction)
        //{
        //}

        //private static Action<IResultAction> ConvertX(Action<GetToDoItemsResultAction> resultAction)
        //{
        //    //return (Action<IResultAction>) resultAction;
        //    var actionObj = new Action<IResultAction>(obj =>
        //    {
        //        var castObj = (IResultAction)Convert.ChangeType(obj, typeof(IResultAction));
        //        //resultAction(castObj);
        //    });
        //    return actionObj;
        //}

        
    }
}