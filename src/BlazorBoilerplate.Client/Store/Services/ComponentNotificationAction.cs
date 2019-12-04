using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Client.Store.Services
{
    public class ComponentNotificationAction
    {
        public ComponentNotificationAction(object action)
        {
            Action = action;
        }

        public object Action { get; private set; }
    }
}
