using Csharpik.Core.Models.BookModels;
using Csharpik.Core.Models.BookModels.dto;
using Csharpik.Core.Repositories.CommonRepositories;
using Csharpik.Core.Services.Interfaces.BookServices;

namespace Csharpik.Core.Services.BookServices
{
    public class AuthorService : IBookService<AuthorDto>
    {
        private readonly IRepository<Author> _authorRepository;

        public AuthorService(IRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public IEnumerable<AuthorDto> GetAll()
        {
            IEnumerable<Author> authors = _authorRepository.GetAll();
            List<AuthorDto> authorDto = new List<AuthorDto>();

            foreach (Author author in authors)
            {
                authorDto.Add(new AuthorDto(author));
            }

            return authorDto;
        }

        public AuthorDto GetById(int id)
        {
            AuthorDto dto = new AuthorDto(_authorRepository.GetById(id));

            return dto;
        }
    }
}
