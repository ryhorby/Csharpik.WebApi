using Csharpik.Core.Models.BookModels;
using Csharpik.Core.Models.BookModels.dto;
using Csharpik.Core.Repositories.CommonRepositories;
using Csharpik.Core.Services.Interfaces.BookServices;

namespace Csharpik.Core.Services.BookServices
{
    public class AuthorService : IBookService<AuthorDto>
    {
        private readonly IRepository<AuthorDto> _authorRepository;

        public AuthorService(IRepository<AuthorDto> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public IEnumerable<AuthorDto> GetAll()
        {
            IEnumerable<AuthorDto> authors = _authorRepository.GetAll();

            return authors;
        }

        public AuthorDto GetById(int id)
        {
            return _authorRepository.GetById(id);
        }
    }
}
