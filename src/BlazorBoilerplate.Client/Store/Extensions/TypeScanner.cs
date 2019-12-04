﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BlazorBoilerplate.Client.Store.Extensions
{
    public static class TypeScanner
    {
        // https://stackoverflow.com/a/52411210/54159
        public static IEnumerable<MethodInfo> GetMethodsBySignature(this Type type,
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
