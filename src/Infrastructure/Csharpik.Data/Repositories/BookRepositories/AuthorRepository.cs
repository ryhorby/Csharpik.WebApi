using Csharpik.Core.Models.BookModels;
using Csharpik.Core.Repositories.CommonRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Csharpik.Data.Repositories.BookRepositories
{
    public class AuthorRepository : IRepository<Author>
    {
        private readonly CsharpikContext _context;

        public AuthorRepository(CsharpikContext context)
        {
            _context = context;
        }

        public List<Author> GetAll()
        {
            try
            {
                List<Author> authors = _context.Authors.ToList();

                return authors;
            }
            catch (ArgumentNullException ex)
            {
                throw new HttpRequestException("This book was not found", ex, HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                throw new HttpRequestException(ex.Message, ex, HttpStatusCode.BadGateway);
            }
        }

        public Author GetById(int id)
        {
            try
            {
                Author author = _context.Authors.FirstOrDefault(x => x.Id == id);

                return author;
            }
            catch (ArgumentNullException ex)
            {
                throw new HttpRequestException("This book was not found", ex, HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                throw new HttpRequestException(ex.Message, ex, HttpStatusCode.BadGateway);
            }
        }

        public void Create(Author author)
        {
            try
            {
                _context.Add(author);
            }
            catch (ArgumentNullException ex)
            {
                throw new HttpRequestException("This book was not found", ex, HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                throw new HttpRequestException(ex.Message, ex, HttpStatusCode.BadGateway);
            }
        }
    }
}
