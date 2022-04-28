using Csharpik.Core.Models.BookModels;
using Csharpik.Core.Repositories;

namespace Csharpik.Core.Services
{
    public class BookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        
        public IEnumerable<Book> GetAllBooks()
        {
            return _bookRepository.GetAllBooks();  
        }

        public Book GetBookById(int id)
        {
            return _bookRepository.GetBookById(id);
        }
    }
}
