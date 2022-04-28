using Csharpik.Core.Models.BookModels;

namespace Csharpik.Core.Repositories
{
    public interface IBookRepository
    {
        public List<Book> GetAllBooks();

        public Book GetBookById(int id);
    }
}
