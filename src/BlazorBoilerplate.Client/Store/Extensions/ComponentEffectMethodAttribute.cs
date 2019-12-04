using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Client.Store.Extensions
{
    // the signature of the method must be
    // public void HandleAction(SomeResultAction action)
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class ComponentEffectMethodAttribute : Attribute
    {
    }
}
