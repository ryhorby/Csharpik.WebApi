using Csharpik.Core.Models.BookModels.dto;
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

        public List<BookDto> GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }
    }
}
