namespace ServiceAutoInjector.Interfaces
{
    public interface IAnimalService : IOtherService
    {
        Task<string> GetAnimalNameAsync(int catId);
    }
}
