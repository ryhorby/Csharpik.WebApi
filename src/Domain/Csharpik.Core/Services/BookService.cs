using Csharpik.Core.Models.BookModels;
using Csharpik.Core.Models.Common;
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
        
        public ObjectListDto GetAllBooks()
        {
            return _bookRepository.GetAllBooks();  
        }

        public ObjectDto GetBookById(int id)
        {
            return _bookRepository.GetBookById(id);
        }
    }
}
