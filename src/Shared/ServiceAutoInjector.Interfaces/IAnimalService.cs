namespace ServiceAutoInjector.Interfaces
{
    public interface IAnimalService : IOtherProjectService
    {
        Task<string> GetAnimalNameAsync(int catId);
    }
}
