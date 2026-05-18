namespace ServiceAutoInjector.Interfaces
{
    public interface IFurnitureService : IOtherService
    {
        Task<string> GetFurnitureNameAsync(int furnitureId);
    }
}
