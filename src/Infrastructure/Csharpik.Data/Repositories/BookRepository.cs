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
            return _cotnext.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            return _cotnext.Books.Where(b => b.Id == id).FirstOrDefault();
        }
    }
}
