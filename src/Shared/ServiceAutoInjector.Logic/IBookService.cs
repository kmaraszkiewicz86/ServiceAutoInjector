namespace ServiceAutoInjector.Logic
{

    public interface IBookService: IService
    {
        Task<string> GetBookTitleAsync(int bookId);
    }
}
