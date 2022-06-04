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

        public IEnumerable<Author> GetAll()
        {
            IEnumerable<Author> authors = _context.Authors;

            return authors;
        }

        public Author GetById(int id)
        {
            Author author = _context.Authors.FirstOrDefault(x => x.Id == id);

            return author;
        }

        /* TODO: Realize creating
        public void Create(Author author)
        {
            _context.Add(author);
        }
        */
    }
}
