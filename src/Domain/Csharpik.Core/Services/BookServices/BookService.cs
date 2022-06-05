using Csharpik.Core.Models.BookModels;
using Csharpik.Core.Models.BookModels.dto;
using Csharpik.Core.Repositories.CommonRepositories;
using Csharpik.Core.Services.Interfaces.BookServices;

namespace Csharpik.Core.Services
{
    public class BookService : IBookService<BookDto>
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<Author> _authorRepository;

        public BookService(IRepository<Book> bookRepository, IRepository<Author> authorRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
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

        //TODO: Check on author exist or not and return correct exceprion 404
        public void Create(BookDto item)
        {
            List<Author> authors = new List<Author>();

            foreach (int id in item.AuthorsId)
            {
                authors.Add(_authorRepository.GetById(id));
            }

            Book book = new Book(item);
            book.Authors = authors;

            _bookRepository.Create(book);
        }

        public BookDto Update(BookDto item)
        {
            List<Author> authors = new List<Author>();

            foreach (int id in item.AuthorsId)
            {
                authors.Add(_authorRepository.GetById(id));
            }

            Book book = new Book(item, item.Id);
            book.Authors = authors;

            book = _bookRepository.Update(book);

            BookDto dto = new BookDto(book);

            return dto;
        }

        public void Delete(int id)
        {
            _bookRepository.Delete(id);
        }
    }
}
