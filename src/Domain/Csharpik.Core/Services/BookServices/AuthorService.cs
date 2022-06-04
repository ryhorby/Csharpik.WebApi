using Csharpik.Core.Models.BookModels;
using Csharpik.Core.Repositories.CommonRepositories;
using Csharpik.Core.Services.Interfaces.BookServices;

namespace Csharpik.Core.Services.BookServices
{
    public class AuthorService : IBookService<Author>
    {
        private readonly IRepository<Author> _authorRepository;

        public AuthorService(IRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public IEnumerable<Author> GetAll()
        {
            return _authorRepository.GetAll();
        }

        public Author GetById(int id)
        {
            return _authorRepository.GetById(id);
        }
    }
}
