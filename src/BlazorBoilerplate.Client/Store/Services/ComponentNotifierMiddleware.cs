using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;
using BlazorBoilerplate.Client.Store.Extensions;

namespace BlazorBoilerplate.Client.Store.Services
{
    public class ComponentNotifierMiddleware : Middleware
    {
        private readonly ComponentNotifierService _componentNotifierService;

        public ComponentNotifierMiddleware(ComponentNotifierService componentNotifierService)
        {
            _componentNotifierService = componentNotifierService;
        }

        public override void AfterDispatch(object action)
        {
            base.AfterDispatch(action);

            // check if it's a special action (ComponentNotificationAction)
            // then use ComponentNotificationService to notify registered components
            //Console.WriteLine($"Action {action.GetType().Name} has just been dispatched to all features");

            if (action is ComponentNotificationAction componentNotificationAction)
            {
                // Console.WriteLine($"Detected ComponentNotificationAction...forwarding {componentNotificationAction.Action}");
                _componentNotifierService.ForwardAction(componentNotificationAction.Action);
            }

            // ODER:
            // - action chains definieren:
            //      GetToDoItemsAction => GetToDoItemsResultAction (forward original action within resultAction?)
            // - GetToDoItemsAction hat NotificationAction
            //      [JsonIgnore] public Action<GetToDoItemsResultAction> NotificationAction { get; set; }
            // - invoke Notification here/in componentNotifierService?
        }
    }
}
