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
        public IEnumerable<Book> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public Book GetBookById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
