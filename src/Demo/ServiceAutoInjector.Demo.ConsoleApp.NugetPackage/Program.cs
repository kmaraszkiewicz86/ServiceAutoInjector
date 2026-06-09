using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceAutoInjector.Demo.ConsoleApp.NugetPackage;
using ServiceAutoInjector.Interfaces;
using ServiceAutoInjector.Logic;

Console.WriteLine("Demo of ServiceAutoInjector:");


var hostWithManualyCreatedServices = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddRequiredManualyServices();
    })
    .Build();

var hostWithAutomaticallyCreatedServices = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddRequiredServicesByServiceAutoInjector();
    })
    .Build();

await RunServicesAsync(hostWithManualyCreatedServices.Services);
await RunServicesAsync(hostWithAutomaticallyCreatedServices.Services);

static async Task RunServicesAsync(IServiceProvider serviceProvider)
{
    // Book Service
    var bookService = serviceProvider.GetRequiredService<IBookService>();
    var bookTitle = await bookService.GetBookTitleAsync(1);
    Console.WriteLine($"Book Title: {bookTitle}");

    // Author Service
    var authorService = serviceProvider.GetRequiredService<IAuthorService>();
    var authorName = await authorService.GetAuthorNameAsync(1);
    Console.WriteLine($"Author Name: {authorName}");

    // Admin Service
    var adminService = serviceProvider.GetRequiredService<IAdminService>();
    var adminName = await adminService.GetAdminNameAsync();
    Console.WriteLine($"Admin Name: {adminName}");

    // Furniture Service
    var furnitureService = serviceProvider.GetRequiredService<IFurnitureService>();
    var furnitureName = await furnitureService.GetFurnitureNameAsync(1);
    Console.WriteLine($"Furniture Name: {furnitureName}");

    // Animal Service
    var animalService = serviceProvider.GetRequiredService<IAnimalService>();
    var animalName = await animalService.GetAnimalNameAsync(1);
    Console.WriteLine($"Animal Name: {animalName}");
}