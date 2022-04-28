using Csharpik.Core.Models.BookModels;
using Csharpik.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharpik.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly CsharpikContext _cotnext;

        public BookRepository(CsharpikContext cotnext)
        {
            _cotnext = cotnext;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            List<Book> books = _cotnext.Books.ToList();
            
            return books;
        }

        public Book GetBookById(int id)
        {
            Book book = _cotnext.Books.Where(b => b.Id == id).Single();

            return book;
        }
    }
}
