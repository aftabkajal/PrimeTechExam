using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PrimeTech.Interview.Business.Infrastructure.Extensions
{
    public static class Extensions
    {
        public static void RegisterCollection(this IServiceCollection services, Type openGenericServiceType, IEnumerable<Assembly> assemblies)
        {
            var types = assemblies
                .Distinct()
                .Where(a => !a.IsDynamic)
                .SelectMany(GetTypesFromAssembly)
                .Where(type => !type.IsGenericTypeDefinition && IsAssignableToGenericType(type, openGenericServiceType))
                .ToList();

            foreach (var type in types)
            {
                var interfaceType = type.GetInterfaces().FirstOrDefault(i => IsAssignableToGenericType(i, openGenericServiceType));
                if (interfaceType != null)
                {
                    services.AddScoped(interfaceType, type);
                }
            }
        }

        public static void RegisterCollection<TService>(this IServiceCollection services, IEnumerable<Assembly> assemblies) where TService : class
        {
            RegisterCollection(services, typeof(TService), assemblies);
        }

        private static bool IsAssignableToGenericType(Type givenType, Type genericType)
        {
            var interfaceTypes = givenType.GetInterfaces();

            foreach (var it in interfaceTypes)
            {
                if (it.IsGenericType && it.GetGenericTypeDefinition() == genericType)
                {
                    return true;
                }
            }

            var baseType = givenType.BaseType;
            if (baseType == null) return false;

            return baseType.IsGenericType && baseType.GetGenericTypeDefinition() == genericType || IsAssignableToGenericType(baseType, genericType);
        }

        private static IEnumerable<Type> GetTypesFromAssembly(Assembly assembly) => assembly.GetTypes();
    }
}
