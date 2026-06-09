using ServiceAutoInjector.Interfaces;
using ServiceAutoInjector.Logic;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceAutoInjector.Demo.ConsoleApp.LocalPackage
{
    public static class DependencyInjectionExtension
    {
        extension(IServiceCollection services)
        {
            public IServiceCollection AddRequiredManualyServices()
            {
                services.AddTransient<IBookService, BookService>();
                services.AddTransient<IAuthorService, AuthorService>();
                services.AddTransient<IAdminService, AdminService>();
                services.AddTransient<IFurnitureService, FurnitureService>();
                services.AddTransient<IAnimalService, AnimalService>();

                return services;
            }

            public IServiceCollection AddRequiredServicesByServiceAutoInjector()
            {
                services.AddClassesToDependencyInjection(typeof(IService), serviceLifetime: ServiceLifetime.Transient);
                services.AddClassesToDependencyInjection(typeof(IOtherProjectService), null, typeof(FurnitureService).Assembly, ServiceLifetime.Transient);

                return services;
            }
        }
    }
}
