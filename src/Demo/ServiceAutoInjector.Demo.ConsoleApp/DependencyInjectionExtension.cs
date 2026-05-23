using ServiceAutoInjector.Interfaces;
using ServiceAutoInjector.Logic;
using ServiceAutoInjector;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceAutoInjector.Demo.Extensions
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
                services.AddClassesToDependencyInjection(typeof(IService));
                services.AddClassesToDependencyInjection(typeof(IOtherService));

                return services;
            }
        }
    }
}
