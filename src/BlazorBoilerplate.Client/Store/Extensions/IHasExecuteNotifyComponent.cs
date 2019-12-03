using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Client.Store.Extensions
{
    public interface IHasExecuteNotifyComponent<T>
    {
        void ExecuteNotifyComponent();

        [JsonIgnore] Action<T> NotificationAction { get; }
    }
}