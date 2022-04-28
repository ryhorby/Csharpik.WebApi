using Csharpik.Core.Models.BookModels;
using Csharpik.Core.Models.BookModels.dto;
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
        private readonly CsharpikContext _context;

        public BookRepository(CsharpikContext context)
        {
            _context = context;
        }

        public List<Book> GetAllBooks()
        {
            List<Book> books = _context.Books.ToList();
            
            return books;
        }

        public Book GetBookById(int id)
        {
            Book book = _context.Books.FirstOrDefault(x => x.Id == id);

            return book;
        }
    }
}
