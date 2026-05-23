namespace ServiceAutoInjector.Logic
{
    public class BookService : IBookService
    {
        public async Task<string> GetBookTitleAsync(int bookId)
        {
            await Task.Delay(100);
            return "Title of book with ID " + bookId;
        }
    }
}
