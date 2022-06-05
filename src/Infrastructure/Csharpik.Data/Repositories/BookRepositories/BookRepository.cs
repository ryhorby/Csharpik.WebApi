﻿using Csharpik.Core.Models.BookModels;
using Csharpik.Core.Repositories.CommonRepositories;
using Microsoft.EntityFrameworkCore;

namespace Csharpik.Data.Repositories
{

    //TODO: Catch 404
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

        // TODO: Realize creating
        public void Create(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
