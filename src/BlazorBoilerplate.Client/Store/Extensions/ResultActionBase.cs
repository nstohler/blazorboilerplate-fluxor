using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BlazorBoilerplate.Client.Store.FetchToDo.Get;

namespace BlazorBoilerplate.Client.Store.Extensions
{
    public class ResultActionBase : IResultAction
    {
        public ResultActionBase(ResultActionBase actionBase)
        {
            ResultAction = actionBase.ResultAction;

            Data         = actionBase.Data;
            IsSuccess    = actionBase.IsSuccess;
            ErrorMessage = actionBase.ErrorMessage;
        }

        public ResultActionBase(Action<IResultAction> resultAction)
        {
            ResultAction = resultAction;
        }

        [JsonIgnore] protected Action<IResultAction> ResultAction { get; private set; }

        public void ExecuteResultAction(IResultAction action)
        {
            this.ResultAction?.Invoke(action);
        }

        public void ExecuteResultActionWithCast<TResultAction>(TResultAction action) where TResultAction : class
        {
            var castParamAction = action as TResultAction;
            var castAction      = ResultAction as Action<TResultAction>;

            castAction?.Invoke(castParamAction);
        }

        public object Data         { get; protected set; }
        public bool   IsSuccess    { get; protected set; }
        public string ErrorMessage { get; protected set; }
    }
}