using Csharpik.Core.Models.BookModels;
using Csharpik.Core.Models.BookModels.dto;
using Csharpik.Core.Repositories.CommonRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Csharpik.Data.Repositories.BookRepositories
{
    public class AuthorRepository : IRepository<AuthorDto>
    {
        private readonly CsharpikContext _context;

        public AuthorRepository(CsharpikContext context)
        {
            _context = context;
        }

        public IEnumerable<AuthorDto> GetAll()
        {
            IEnumerable<Author> authors = _context.Authors
                  .Include(a => a.Books);

            IEnumerable <AuthorDto> data = _context.Authors
                   .Include(a => a.Books)
                   .Select(x => new AuthorDto
                   {
                       Id = x.Id,
                       Name = x.Name,
                       Biography = x.Biography,
                       BooksId = x.Books.Select(b => b.Book.Id).ToList()
                   });

            return data;
        }

        public AuthorDto GetById(int id)
        {
            Author author = _context.Authors.FirstOrDefault(x => x.Id == id);

            //HACK:
            return new AuthorDto();
        }

        /* TODO: Realize creating
        public void Create(Author author)
        {
            _context.Add(author);
        }
        */
    }
}
