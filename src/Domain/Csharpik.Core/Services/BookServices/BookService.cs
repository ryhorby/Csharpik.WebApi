using Csharpik.Core.Models.BookModels.dto;
using Csharpik.Core.Models.BookModels;
using Csharpik.Core.Repositories.CommonRepositories;
using System.Net;
using Csharpik.Core.Services.BookServices;

namespace Csharpik.Core.Services
{
    public class BookService
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly AuthorService _authorService;

        public BookService(IRepository<Book> bookRepository, AuthorService authorService)
        {
            _bookRepository = bookRepository;
            _authorService = authorService;
        }

        public List<BookDto> GetAll()
        {
            List<Book> books = _bookRepository.GetAll();
            
            List<BookDto> dtoBooks = ConvertListBookEntitiesToDtoList(books);

            return dtoBooks;
        }

        public BookDto GetById(int id)
        {
            Book book = _bookRepository.GetById(id);

            BookDto bookDto = BookEntityToDto(book);

            return bookDto;
        }

        public void Create(BookDto bookDto)
        {
            Book book = BookDtoToEntity(bookDto);
            _bookRepository.Create(book);
        }

        #region Entitiy To Dto
        private List<BookDto> ConvertListBookEntitiesToDtoList(List<Book> books)
        {
            List<BookDto> dtoBooks = new List<BookDto>();

            foreach (Book book in books)
            {
                dtoBooks.Add(BookEntityToDto(book));
            }

            return dtoBooks;
        }

        private BookDto BookEntityToDto(Book book)
        {
            BookDto dtoBook = new BookDto();
            dtoBook.Id = book.Id;
            dtoBook.Title = book.Title;
            dtoBook.Description = book.Description;
            dtoBook.IsFree = book.IsFree;
            dtoBook.AuthorsIdList = ConvertAuthorsListToAuthorIdList(book.Authors);

            return dtoBook;
        }

        private List<int> ConvertAuthorsListToAuthorIdList(List<Author> authors)
        {
            List<int> AuthorIdList = new List<int>();

            foreach (Author author in authors)
            {
                AuthorIdList.Add(author.Id);
            }

            return AuthorIdList;
        }
        #endregion

        #region Dto to Entity

        private Book BookDtoToEntity(BookDto bookDto)
        {
            Book book = new Book();
            book.Title = bookDto.Title;
            book.Description = bookDto.Description;
            book.IsFree = bookDto.IsFree;
            book.Authors = ConvertAuthorsIdListToAuthorList(bookDto.AuthorsIdList);

            return book;
        }

        private List<Author> ConvertAuthorsIdListToAuthorList(List<int> authorsIdList)
        {
            List<Author> authors = new List<Author>();

            foreach (int id in authorsIdList)
            {
                authors.Add(_authorService.GetAuthorEntityById(id));
            }

            return authors;
        }

        #endregion
    }
}
