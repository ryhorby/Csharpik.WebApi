using Csharpik.Core.Models.BookModels;
using Csharpik.Core.Repositories.CommonRepositories;
using Csharpik.Core.Services.Interfaces.BookServices;

namespace Csharpik.Core.Services
{
    public class BookService : IBookService<Book>
    {
        private readonly IRepository<Book> _bookRepository;

        public BookService(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }

        public Book GetById(int id)
        {
            return _bookRepository.GetById(id);
        }
    }
}
