using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Client.Store.Extensions
{
    // https://stackoverflow.com/a/50422012/54159

    public static class StateFactory
    {
        private static List<IStateFactoryObject> knownObjects = new List<IStateFactoryObject>();

        public static void RegisterType(IStateFactoryObject obj)
        {
            knownObjects.Add(obj);
        }

        public static T Instantiate<T>() where T : IStateFactoryObject
        {
            var knownObject = knownObjects.Where(x => x.GetType() == typeof(T));
            return (T) ((IStateFactoryObject)knownObject).Instantiate();
        }
    }
}
