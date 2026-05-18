namespace ServiceAutoInjector.Logic
{
    public interface IAuthorService : IService
    {
        Task<string> GetAuthorNameAsync(int authorId);
    }
}
