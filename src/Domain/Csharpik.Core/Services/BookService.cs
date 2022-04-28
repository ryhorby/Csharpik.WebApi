using Csharpik.Core.Models.BookModels.dto;
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

        public List<BookDto> GetAllBooks()
        {
            List<Book> books = _bookRepository.GetAllBooks();
            
            List<BookDto> dtoBooks = new List<BookDto>();

            foreach (var book in books)
            {
                dtoBooks.Add(new BookDto(
                    book.Id, book.Title, book.Description)
                    );
            }

            return dtoBooks;
        }

        public BookDto GetBookById(int id)
        {
            Book book = _bookRepository.GetBookById(id);

            BookDto bookDto = new BookDto(book.Id, book.Title, book.Description);

            return bookDto;
        }
    }
}
