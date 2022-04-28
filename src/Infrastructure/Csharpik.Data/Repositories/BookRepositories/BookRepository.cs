using Csharpik.Core.Models.BookModels;
using Csharpik.Core.Models.BookModels.dto;
using Csharpik.Core.Repositories;
using Csharpik.Core.Repositories.CommonRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Csharpik.Data.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        private readonly CsharpikContext _context;

        public BookRepository(CsharpikContext context)
        {
            _context = context;
        }

        public List<Book> GetAll()
        {
            try
            {
                List<Book> books = _context.Books.ToList();

                return books;
            }
            catch (Exception ex)
            {
                throw new HttpRequestException(ex.Message, ex, HttpStatusCode.BadGateway);
            }
        }

        public Book GetById(int id)
        {
            try
            {
                Book book = _context.Books.FirstOrDefault(x => x.Id == id);

                return book;
            }
            catch(ArgumentNullException ex)
            {
                throw new HttpRequestException("This book was not found", ex, HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                throw new HttpRequestException(ex.Message, ex, HttpStatusCode.BadGateway);
            }
        }

        public void Create(Book book)
        {
            try
            {
                foreach (Book bookFromDb in GetAll())
                {
                    if (bookFromDb.Title == book.Title)
                        throw new HttpRequestException("This book has already exist", null, HttpStatusCode.Conflict);
                }

                _context.Add(book);
            }
            catch (Exception ex)
            {
                throw new HttpRequestException(ex.Message, ex, HttpStatusCode.BadGateway);
            }
        }
    }
}
