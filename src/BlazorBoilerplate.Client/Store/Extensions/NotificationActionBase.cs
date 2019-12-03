using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Client.Store.Extensions
{
    public abstract class NotificationActionBase<T> : IHasNotificationAction<T>
    {
        [JsonIgnore] public Action<T> NotificationAction { get; set; }
    }
}
