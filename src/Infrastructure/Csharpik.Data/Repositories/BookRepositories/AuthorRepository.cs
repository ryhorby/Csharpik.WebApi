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

    //TODO: Catch 404
    //TODO: Create pagebility
    //TODO: Delete method(if the last authors was deleted, delete book also)

    public class AuthorRepository : IRepository<Author>
    {
        private readonly CsharpikContext _context;

        public AuthorRepository(CsharpikContext context)
        {
            _context = context;
        }

        public IEnumerable<Author> GetAll()
        {
            IEnumerable<Author> authors = _context.Authors
                  .Include(a => a.Books);

            return authors;
        }

        public Author GetById(int id)
        {
            Author author = _context.Authors.Include(a => a.Books)
                                    .FirstOrDefault(x => x.Id == id);

            return author;
        }

        public void Create(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public Author Update(Author author)
        {
            var dbAuthor = _context.Authors.Find(author.Id);
            if (dbAuthor == null)
                throw new NullReferenceException("Author with this id is not exist");

            dbAuthor.Name = author.Name;
            dbAuthor.Surname = author.Surname;
            dbAuthor.Biography = author.Biography;
            
            //HACK:
            dbAuthor.Books = author.Books;
            
            _context.SaveChanges();

            return author;
        }

        public void Delete(int id)
        {
            var dbAuthor = _context.Authors.Find(id);
            if (dbAuthor == null)
                throw new NullReferenceException("Author with this id is not exist");
            
            _context.Authors.Remove(dbAuthor);
            _context.SaveChanges();
        }
    }
}