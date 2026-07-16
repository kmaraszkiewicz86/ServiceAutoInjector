using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Reflection;

namespace ServiceAutoInjector
{
    /// <summary>
    /// Extension methods for IServiceCollection to automatically register services based on interfaces and their implementations.
    /// </summary>
    public static class ServiceAutoInjectorExtension
    {
        extension(IServiceCollection services) 
        {
            /// <summary>
            /// Scans for all interfaces in the specified assembly that implement the given global interface type, and registers their implementations in the dependency injection container.
            /// </summary>
            /// <param name="globalInterfaceType">The global interface type</param>
            /// <param name="assembly">The assembly to search for implementations</param>
            /// <param name="implementationAssembly">The assembly containing implementation types</param>
            /// <param name="serviceLifetime">The lifetime of the service</param>
            /// <returns>The updated service collection</returns>
            public IServiceCollection AddClassesToDependencyInjection(
                Type globalInterfaceType,
                Assembly? assembly = null,
                Assembly? implementationAssembly = null,
                ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
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

                    if (classes.Length == 0)
                    {
                        Debug.WriteLine($"Skipping {interfaceType.FullName} because it doesn't implement any implementation classes.");
                        continue;
                    }

                    foreach (Type implementationType in classes)
                    {
                        services.Add(new ServiceDescriptor(interfaceType, implementationType, serviceLifetime));
                    }
                }

                return services;
            }
        }
    }
}
