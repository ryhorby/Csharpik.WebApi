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

        public List<BookDto> GetAllBooks()
        {
            List<Book> books = _context.Books.ToList();
            List<BookDto> dtoBooks = new List<BookDto>();

            foreach (var book in books)
            {
                dtoBooks.Add(new BookDto(
                    book.Id, book.Title, book.Description)
                    );
            }
  
            return dtoBooks;
        }
    }
}
