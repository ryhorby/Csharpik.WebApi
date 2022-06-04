using Csharpik.Core.Models.BookModels;
using Csharpik.Core.Repositories.CommonRepositories;

namespace Csharpik.Data.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        private readonly CsharpikContext _context;

        public BookRepository(CsharpikContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetAll()
        {
            IEnumerable<Book> books = _context.Books;
           
            return books;
        }

        public Book GetById(int id)
        {
            Book book = _context.Books.FirstOrDefault(x => x.Id == id);

            return book;
        }

        /* TODO: Realize creating
        public void Create(Book book)
        {
            _context.Add(book);
        }
        */
    }
}
