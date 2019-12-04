using System;
using System.Collections.Generic;
using System.Linq;
using BlazorBoilerplate.Client.Store.Extensions;

namespace BlazorBoilerplate.Client.Store.Services
{
    public class ComponentNotifierService
    {
        public ComponentNotifierService()
        {
            Console.WriteLine($"ComponentNotifierService ctor!!!");

            //// get types that implement IFluxorComponentWithReactions
            //// https://stackoverflow.com/a/52411210/54159
            //_typesImplementingIFluxorComponentWithReactions = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
            //    .Where(x => typeof(IFluxorComponentWithReactions).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
            //    .Select(x => x).ToList();
        }

        //private readonly List<Type> _typesImplementingIFluxorComponentWithReactions;
        
        private readonly HashSet<IFluxorComponentWithReactions> _registeredComponents = new HashSet<IFluxorComponentWithReactions>();

        public void Register(IFluxorComponentWithReactions component)
        {
            _registeredComponents.Add(component);
        }

        public void Unregister(IFluxorComponentWithReactions component)
        {
            _registeredComponents.Remove(component);
        }

        public void ForwardAction(object action)
        {
            foreach (var registeredComponent in _registeredComponents)
            {
                // _typesImplementingIFluxorComponentWithReactions
                //var matchingTypes = _typesImplementingIFluxorComponentWithReactions
                //    .Where(x => x.FullName == registeredComponent.GetType().FullName)
                //    .ToList();

                //foreach (var matchingType in matchingTypes)
                //{
                //    Console.WriteLine($"... matching name: {registeredComponent.GetType().FullName} : {matchingType.FullName}");
                //}

                // find methods 
                var methods = registeredComponent.GetType().GetMethodsBySignature(
                    typeof(void),
                    //null,
                    typeof(ComponentEffectMethodAttribute),
                    false,
                    action.GetType() // gets concrete type!
                ).ToList();

                // store dict/action => List<MethodInfo> type combo?

                // call all methods with matching signature on registeredComponent
                if (methods.Any())
                {
                    var instance = registeredComponent;
                    foreach (var methodInfo in methods)
                    {
                        methodInfo.Invoke(instance, new[] { action });
                    }
                }
                else
                {
                    // no methods with matching signature found!
                    // Console.WriteLine($"!!!xxx!!ComponentNotifierService.ForwardAction no methods found!!xxx!!!");
                }
            }
        }

    }
}