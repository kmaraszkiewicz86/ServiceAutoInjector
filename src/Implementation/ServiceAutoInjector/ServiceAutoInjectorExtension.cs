using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ServiceAutoInjector
{
    public static class ServiceAutoInjectorExtension
    {
        extension(IServiceCollection services) 
        {
            public IServiceCollection AddClassesToDependencyInjection(Type globalInterfaceType, Assembly? assembly = null, Assembly? implementationAssembly = null)
            {
                assembly ??= globalInterfaceType.Assembly;

                Type[] types = assembly.GetTypes()
                    .Where(t => t is { IsInterface: true }
                                && t.GetInterfaces().Contains(globalInterfaceType))
                    .ToArray();

                foreach (Type interfaceType in types)
                {
                    Type[]? classesFromInterfaceAssembly = assembly.GetTypes()
                        .Where(t => t is { IsClass: true, IsAbstract: false }
                                    && t.GetInterfaces().Contains(interfaceType))
                        .ToArray();

                    Type[]? classesFromImplementationAssembly = implementationAssembly?.GetTypes()
                        .Where(t => t is { IsClass: true, IsAbstract: false }
                                    && t.GetInterfaces().Contains(interfaceType))
                        .ToArray();

                    Type[] classes = [];

                    if (classesFromInterfaceAssembly != null)
                    {
                        classes = [.. classesFromInterfaceAssembly];
                    }

                    if (classesFromImplementationAssembly != null)
                    {
                        classes = [.. classes, .. classesFromImplementationAssembly];
                    }

                    if (classes.Length == 0) {
                        Debug.WriteLine($"Skipping {interfaceType.FullName} because it doesn't implement any implementation classes.");
                        continue;
                    }

                    foreach (Type implementationType in classes)
                    {
                        services.AddTransient(interfaceType, implementationType);
                    }
                }

                return services;
            }
        }
    }
}
