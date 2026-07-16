using ServiceAutoInjector.Interfaces;
using ServiceAutoInjector.Logic;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceAutoInjector.Demo.ConsoleApp.LocalPackage
{
    /// <summary>
    /// Provides extension methods for IServiceCollection to register required services for the demo application.
    /// </summary>
    public static class DependencyInjectionExtension
    {
        extension(IServiceCollection services)
        {
            /// <summary>
            /// Demonstrates manual service registration in the dependency injection container.
            /// </summary>
            /// <returns>The updated <see cref="IServiceCollection"/>.</returns>
            public IServiceCollection AddRequiredManuallyServices()
            {
                services.AddTransient<IBookService, BookService>();
                services.AddTransient<IAuthorService, AuthorService>();
                services.AddTransient<IAdminService, AdminService>();
                services.AddTransient<IFurnitureService, FurnitureService>();
                services.AddTransient<IAnimalService, AnimalService>();

                return services;
            }

            /// <summary>
            /// Demonstrates automatic service registration in the dependency injection container using ServiceAutoInjector.
            /// </summary>
            /// <returns>The updated <see cref="IServiceCollection"/>.</returns>
            public IServiceCollection AddRequiredServicesByServiceAutoInjector()
            {
                services.AddClassesToDependencyInjection(typeof(IService), serviceLifetime: ServiceLifetime.Transient);
                services.AddClassesToDependencyInjection(typeof(IOtherProjectService), null, typeof(FurnitureService).Assembly, ServiceLifetime.Transient);

                return services;
            }
        }
    }
}
