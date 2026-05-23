using ServiceAutoInjector.Interfaces;

namespace ServiceAutoInjector.Logic
{
    public class FurnitureService : IFurnitureService
    {
        public async Task<string> GetFurnitureNameAsync(int furnitureId)
        {
            await Task.Delay(100);
            return "Furniture Name";
        }
    }
}
