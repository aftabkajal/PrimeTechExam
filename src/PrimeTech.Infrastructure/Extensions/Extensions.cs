using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PrimeTech.Interview.Business.Infrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static void RegisterCollection(this IServiceCollection services, Type openGenericServiceType, IEnumerable<Assembly> assemblies)
    {
        var types =
           from assembly in assemblies.Distinct()
           where !assembly.IsDynamic
           from type in GetTypesFromAssembly(assembly)
           where !type.IsGenericTypeDefinition
           where ServiceIsAssignableFromImplementation(openGenericServiceType, type)
           select type;

        foreach (var type in types)
        {
            var genericimplementationType = type.GetTypeInfo().ImplementedInterfaces.First();
            services.AddScoped(genericimplementationType, type);
        }
    }

    public static void RegisterCollection<TService>(this IServiceCollection services, IEnumerable<Assembly> assemblies) where TService : class
    {
        var serviceType = typeof(TService);

        RegisterCollection(services, serviceType, assemblies);
    }


    private static bool ServiceIsAssignableFromImplementation(Type service, Type implementation)
    {
        if (!service.IsGenericType)
        {
            return service.IsAssignableFrom(implementation);
        }

        if (implementation.IsGenericType && implementation.GetGenericTypeDefinition() == service)
        {
            return true;
        }

        foreach (Type interfaceType in implementation.GetInterfaces())
        {
            if (IsGenericImplementationOf(interfaceType, service))
            {
                return true;
            }
        }

        // PERF: We don't call GetBaseTypes(), to prevent memory allocations.
        Type baseType = implementation.BaseType ?? (implementation != typeof(object) ? typeof(object) : null);

        while (baseType != null)
        {
            if (IsGenericImplementationOf(baseType, service))
            {
                return true;
            }

            baseType = baseType.BaseType;
        }

        return false;
    }
    private static bool IsGenericImplementationOf(Type type, Type serviceType) =>
      type == serviceType
      || serviceType.IsVariantVersionOf(type)
      || (type.IsGenericType && type.GetGenericTypeDefinition() == serviceType);

    private static bool IsVariantVersionOf(this Type type, Type otherType) =>
        type.IsGenericType
        && otherType.IsGenericType
        && type.GetGenericTypeDefinition() == otherType.GetGenericTypeDefinition()
        && type.IsAssignableFrom(otherType);

    private static IEnumerable<Type> GetTypesFromAssembly(Assembly assembly)
    {
        return assembly.GetTypes();
    }

}
