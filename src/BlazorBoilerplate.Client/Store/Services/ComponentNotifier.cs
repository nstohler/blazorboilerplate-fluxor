using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Blazor.Fluxor;
using BlazorBoilerplate.Client.Pages;
using BlazorBoilerplate.Client.Store.Extensions;
using BlazorBoilerplate.Client.Store.FetchToDo.Get;

namespace BlazorBoilerplate.Client.Store.Services
{
    //public class ComponentNotifier
    //{
    //    private readonly ComponentNotifierService _componentNotifierService;

    //    public ComponentNotifier(ComponentNotifierService componentNotifierService)
    //    {
    //        _componentNotifierService = componentNotifierService;
    //    }

    //    [EffectMethod]
    //    public Task HandleAsync(GetToDoItemsResultAction action, IDispatcher dispatcher)
    //    {
    //        Console.WriteLine($"ComponentNotifier.GetToDoItemsResultAction effect / start callback");

    //        // action.ExecuteNotifyComponent();
    //        _componentNotifierService.ForwardAction(action);

    //        return Task.CompletedTask;
    //    }
    //}

    public class ComponentNotifierService
    {
        public ComponentNotifierService()
        {
            Console.WriteLine($"ComponentNotifierService ctor!!!");

            _typesImplementingIFluxorComponentWithReactions = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof(IFluxorComponentWithReactions).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(x => x).ToList();
        }

        private readonly List<Type> _typesImplementingIFluxorComponentWithReactions;

        private HashSet<IFluxorComponentWithReactions> _registeredComponents = new HashSet<IFluxorComponentWithReactions>();

        public void Register(IFluxorComponentWithReactions component)
        {
            _registeredComponents.Add(component);

            // scan here
            
        }

        public void Unregister(IFluxorComponentWithReactions component)
        {
            _registeredComponents.Remove(component);
        }

        //public void ForwardAction(GetToDoItemsResultAction action)
        public void ForwardAction(object action)
        {
            // (x) instances from _registeredComponents
            // ( ) check if instance(s) have method matching signature
            // ( ) call all methods on their instances

            // get types that implement IFluxorComponentWithReactions
            // https://stackoverflow.com/a/52411210/54159
            //List<Type> types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
            //    .Where(x => typeof(IFluxorComponentWithReactions).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
            //    .Select(x => x).ToList();

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
                var methods = registeredComponent.GetType().GetMethodsBySig(
                    typeof(void),
                    null,
                    false,
                    action.GetType()
                ).ToList();

                if (methods.Any())
                {
                    var instance = registeredComponent;
                    var method   = methods.First();

                    method.Invoke(instance, new[] { action });
                }
                else
                {
                    Console.WriteLine($"!!!xxx!!ComponentNotifierService.ForwardAction no methods found!!xxx!!!");
                }
            }

            //foreach (var registeredComponent in _registeredComponents)
            //{
            //    foreach (var type in _typesImplementingIFluxorComponentWithReactions)
            //    {
            //        if (registeredComponent is type)
            //        {

            //        }
            //    }

            //    if(registeredComponent is )
            //    var methods = firstType.GetMethodsBySig(
            //        typeof(void),
            //        null,
            //        false,
            //        action.GetType()
            //    ).ToList();

            //    var instance = registeredComponent;
            //    var method   = methods.First();
            //    method.Invoke(instance, new[] { action });
            //}

            //---

            //{ 
            //    var firstType = _typesImplementingIFluxorComponentWithReactions.First();

            //    //firstType.inter

            //    //var t = typeof(IFluxorComponentWithReactions);
            //    var methods = firstType.GetMethodsBySig(
            //        typeof(void),
            //        null,
            //        false,
            //        action.GetType()
            //    ).ToList();

            //    Console.WriteLine(
            //        $"ComponentNotifierService.ForwardAction {action.GetType().Name} | {firstType.GetType().Name}");

            //    if (methods.Any())
            //    {
            //        var instance = _registeredComponents.First();
            //        var method   = methods.First();

            //        method.Invoke(instance, new[] {action});
            //    }
            //    else
            //    {
            //        Console.WriteLine($"!!!!!ComponentNotifierService.ForwardAction no methods found!!!!!");
            //    }

            //    //_todos.First().ForwardAction(action);
            //}
        }

    }

    public static class SomeTypeToScan
    {
        // https://stackoverflow.com/a/52411210/54159
        public static IEnumerable<MethodInfo> GetMethodsBySig(this Type type,
            Type returnType,
            Type customAttributeType,
            bool matchParameterInheritence,
            params Type[] parameterTypes)
        {
            return type.GetMethods().Where((m) =>
            {
                if (m.ReturnType != returnType) return false;

                if ((customAttributeType != null) && (m.GetCustomAttributes(customAttributeType, true).Any() == false))
                    return false;

                var parameters = m.GetParameters();

                if ((parameterTypes == null || parameterTypes.Length == 0))
                    return parameters.Length == 0;

                if (parameters.Length != parameterTypes.Length)
                    return false;

                for (int i = 0; i < parameterTypes.Length; i++)
                {
                    if (((parameters[i].ParameterType == parameterTypes[i]) ||
                         (matchParameterInheritence && parameterTypes[i].IsAssignableFrom(parameters[i].ParameterType))) == false)
                        return false;
                }

                return true;
            });
        }
    }
}
