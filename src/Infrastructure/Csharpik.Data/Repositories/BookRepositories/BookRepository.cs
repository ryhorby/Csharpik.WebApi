using Csharpik.Core.Models.BookModels;
using Csharpik.Core.Repositories.CommonRepositories;
using Microsoft.EntityFrameworkCore;

namespace Csharpik.Data.Repositories
{

    //TODO: Catch 404
    //TODO: Create pagebility

    public class BookRepository : IRepository<Book>
    {
        private readonly CsharpikContext _context;

        public BookRepository(CsharpikContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetAll()
        {
            IEnumerable<Book> books = _context.Books
                                      .Include(b => b.Authors);
           
            return books;
        }

        public Book GetById(int id)
        {
            Book book = _context.Books.Include(b => b.Authors)
                                      .FirstOrDefault(x => x.Id == id);

            return book;
        }

        public void Create(Book book)
        {
            _context.Add(book);
            _context.SaveChanges();
        }

        public Book Update(Book book)
        {
            var dbBook = _context.Books.Find(book.Id);
            if (dbBook == null)
                throw new NullReferenceException("Author with this id is not exist");

            dbBook.Title = book.Title;
            dbBook.Description = book.Description;
            dbBook.Authors = book.Authors;
            dbBook.IsFree = book.IsFree;

            _context.SaveChanges();

            return book;
        }

        public void Delete(int id)
        {
            var dbBook = _context.Books.Find(id);
            if (dbBook == null)
                throw new NullReferenceException("Book with this id is not exist");

            _context.Books.Remove(dbBook);
            _context.SaveChanges();
        }
    }
}
