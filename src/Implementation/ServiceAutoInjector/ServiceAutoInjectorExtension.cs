using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Reflection;

namespace ServiceAutoInjector
{
    public static class ServiceAutoInjectorExtension
    {
        extension(IServiceCollection services) 
        {
            public IServiceCollection AddClassesToDependencyInjection(Type type, Assembly? assembly = null)
            {
                assembly ??= type.Assembly;

                Type[] types = assembly.GetTypes()
                    .Where(t => t is { IsClass: true, IsAbstract: false }
                                && t.GetInterfaces().Contains(type))
                    .ToArray();

                foreach (Type implementationType in types)
                {
                    Type? interfaceType = implementationType.GetInterfaces().FirstOrDefault(i => i != type);

                    if (interfaceType is null) {
                        Debug.WriteLine($"Skipping {implementationType.FullName} because it doesn't implement any implementation classes.");
                        continue;
                    }

                    services.AddScoped(interfaceType, implementationType);
                }

                return services;
            }
        }
    }
}
