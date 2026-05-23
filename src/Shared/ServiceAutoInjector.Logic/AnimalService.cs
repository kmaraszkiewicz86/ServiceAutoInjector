using ServiceAutoInjector.Interfaces;

namespace ServiceAutoInjector.Logic
{
    public class AnimalService : IAnimalService
    {
        public async Task<string> GetAnimalNameAsync(int catId)
        {
            await Task.Delay(100);
            return "Animal Name";
        }
    }
}
