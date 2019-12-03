using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BlazorBoilerplate.Client.Store.FetchToDo.Get;

namespace BlazorBoilerplate.Client.Store.Extensions
{
    public class ResultActionBase<TResultAction> : IResultAction
    {
        public ResultActionBase(ResultActionBase<TResultAction> actionBase)
        {
            ResultAction = actionBase.ResultAction;

            Data         = actionBase.Data;
            IsSuccess    = actionBase.IsSuccess;
            ErrorMessage = actionBase.ErrorMessage;
        }

        public ResultActionBase(Action<TResultAction> resultAction)
        {
            ResultAction = resultAction;
        }

        [JsonIgnore] protected Action<TResultAction> ResultAction { get; private set; }

        public void ExecuteResultAction(TResultAction action)
        {
            this.ResultAction?.Invoke(action);
        }

        public object Data         { get; protected set; }
        public bool   IsSuccess    { get; protected set; }
        public string ErrorMessage { get; protected set; }
    }
}