using Csharpik.Core.Models.BookModels;

namespace Csharpik.Core.Repositories
{
    public interface IBookRepository
    {
        public Book GetBookById(int id);
        public IEnumerable<Book> GetAllBooks();
    }
}
