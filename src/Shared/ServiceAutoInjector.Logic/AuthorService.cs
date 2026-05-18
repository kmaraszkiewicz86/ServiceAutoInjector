namespace ServiceAutoInjector.Logic
{
    public class AuthorService : IAuthorService
    {
        public async Task<string> GetAuthorNameAsync(int authorId)
        {
            await Task.Delay(100);
            return "Author Name";
        }
    }
}
