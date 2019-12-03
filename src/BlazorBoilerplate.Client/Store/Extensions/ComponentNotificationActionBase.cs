using System;
using System.Text.Json.Serialization;
using EnsureThat;

namespace BlazorBoilerplate.Client.Store.Extensions
{
    public abstract class ComponentNotificationActionBase<TResultAction> //: IHasExecuteNotifyComponent<TResultAction>
        where TResultAction : class
    {
        public ComponentNotificationActionBase(Action<TResultAction> notificationAction)
        {
            NotificationAction = notificationAction;
        }

        protected ComponentNotificationActionBase(
            ComponentNotificationActionBase<TResultAction> componentNotificationAction)
        {
            NotificationAction = componentNotificationAction.NotificationAction;
        }

        [JsonIgnore] private Action<TResultAction> NotificationAction { get; set; }

        public void ExecuteNotifyComponent()
        {
            var actionParams = this as TResultAction;

            Ensure.That(actionParams).IsNotNull();

            NotificationAction?.Invoke(actionParams);
        }
    }
}