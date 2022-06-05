using Csharpik.Core.Models.BookModels;
using Csharpik.Core.Models.BookModels.dto;
using Csharpik.Core.Repositories.CommonRepositories;
using Csharpik.Core.Services.Interfaces.BookServices;

namespace Csharpik.Core.Services
{
    public class BookService : IBookService<BookDto>
    {
        private readonly IRepository<Book> _bookRepository;

        public BookService(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<BookDto> GetAll()
        {
            IEnumerable<Book> books = _bookRepository.GetAll();
            List<BookDto> booksDto = new List<BookDto>();

            foreach (Book book in books)
            {
                booksDto.Add(new BookDto(book));
            }

            return booksDto;
        }

        public BookDto GetById(int id)
        {
            return new BookDto(_bookRepository.GetById(id));
        }
        
        //TODO:
        public void Create(BookDto item)
        {
            throw new NotImplementedException();
        }
    }
}
