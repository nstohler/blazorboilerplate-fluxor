using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Client.Store.Counter.Report
{
    public class ReportBackToBlazorAction
    {
        public ReportBackToBlazorAction(INotifyBlazorComponent notifyBlazorComponent)
        {
            NotifyBlazorComponent = notifyBlazorComponent;
        }

        public INotifyBlazorComponent NotifyBlazorComponent { get; private set; }
    }

    public interface INotifyBlazorComponent
    {
        void NotifyActionComplete(object action);
    }
}
