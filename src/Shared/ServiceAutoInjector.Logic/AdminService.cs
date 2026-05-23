namespace ServiceAutoInjector.Logic
{
    public class AdminService : IAdminService
    {
        public async Task<string> GetAdminNameAsync()
        {
            await Task.Delay(100);
            return "Admin Name";
        }
    }
}
