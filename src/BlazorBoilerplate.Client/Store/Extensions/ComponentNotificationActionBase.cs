using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BlazorBoilerplate.Client.Store.FetchToDo.Get;

namespace BlazorBoilerplate.Client.Store.Extensions
{
    public class ComponentNotificationActionBase<TResultAction> : IResultAction
        where TResultAction: class
    {
        //public ResultActionBase(ResultActionBase actionBase)
        //{
        //    ResultAction = actionBase.ResultAction;

        //    //Data         = actionBase.Data;
        //    //IsSuccess    = actionBase.IsSuccess;
        //    //ErrorMessage = actionBase.ErrorMessage;
        //}

        public ComponentNotificationActionBase(Action<TResultAction> notificationAction)
        {
            NotificationAction = notificationAction;
        }

        protected ComponentNotificationActionBase(ComponentNotificationActionBase<TResultAction> componentNotificationAction)
        {
            NotificationAction = componentNotificationAction.NotificationAction;
        }

        [JsonIgnore] private Action<TResultAction> NotificationAction { get; set; }

        //public void ExecuteResultAction(IResultAction action)
        //{
        //    this.ResultAction?.Invoke(action);
        //}

        //public static void ExecuteResultAction<TResultAction>(TResultAction resultActionParams)
        //    where TResultAction : IResultAction
        //{
        //    var castAction   = resultActionParams as Action<TResultAction>;

        //    castAction?.Invoke(resultActionParams);
        //}

        public void ExecuteResultAction()
        {
            //var castParamAction = resultActionParams as TResultAction;
            //var castAction      = ResultAction as Action<TResultAction>;

            NotificationAction?.Invoke(this as TResultAction);
        }

        ////public void ExecuteResultAction<TResultAction>(TResultAction resultActionParams)
        ////    where TResultAction : IResultAction
        ////{
        ////    //var castParamAction = resultActionParams as TResultAction;
        ////    //var castAction      = ResultAction as Action<TResultAction>;

        ////    var castAction = Convert<IResultAction, TResultAction>(this.ResultAction);

        ////    castAction?.Invoke(resultActionParams);
        ////}

        //public object Data         { get; protected set; }
        //public bool   IsSuccess    { get; protected set; }
        //public string ErrorMessage { get; protected set; }

        //// https://stackoverflow.com/questions/3444246/convert-actiont-to-actionobject
        //protected static Action<IResultAction> Convert<T>(Action<T> myActionT)
        //    // where T : IResultAction
        //{
        //    //return Convert<T, IResultAction>(myActionT);

        //    if (myActionT == null)
        //    {
        //        return null;
        //    }

        //    return new Action<object>(o => myActionT((T) o));
        //}

        //protected static Action<TOut> Convert<TIn, TOut>(Action<TIn> myActionT)
        //    where TIn : IResultAction
        //    where TOut : IResultAction
        //{
        //    //if (myActionT == null)
        //    //{
        //    //    return null;
        //    //}

        //    var castAction = myActionT as Action<TOut>;

        //    return castAction;

        //    ////return new Action<TOut>(o => myActionT(o));

        //    //if (myActionT == null)
        //    //{
        //    //    return null;
        //    //}
        //    ////var action = new Action<TOut>(obj =>
        //    ////{
        //    ////    var castObj = (TIn)System.Convert.ChangeType(obj, typeof(TOut));
        //    ////    //actionStr(castObj);
        //    ////    myActionT(castObj);
        //    ////});
        //    //var action = new Action<TOut>(obj =>
        //    //{
        //    //    var inAction = myActionT as Action<TOut>;
        //    //    //var castObj = (TIn)System.Convert.ChangeType(obj, typeof(TOut));
        //    //    //actionStr(castObj);
        //    //    //myActionT(castObj);
        //    //    inAction(obj);
        //    //});
        //    //return action;
        //}
    }
}