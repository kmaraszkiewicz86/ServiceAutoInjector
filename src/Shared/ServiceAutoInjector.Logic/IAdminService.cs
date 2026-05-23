namespace ServiceAutoInjector.Logic
{
    public interface IAdminService: IService
    {
        Task<string> GetAdminNameAsync();
    }
}
