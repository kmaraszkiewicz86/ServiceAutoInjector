namespace ServiceAutoInjector.Interfaces
{
    /// <summary>
    /// Added to demostrate how to use ServiceAutoInjector to automatically register services from other projects.
    /// </summary>
    public interface IFurnitureService : IOtherProjectService
    {
        Task<string> GetFurnitureNameAsync(int furnitureId);
    }
}
