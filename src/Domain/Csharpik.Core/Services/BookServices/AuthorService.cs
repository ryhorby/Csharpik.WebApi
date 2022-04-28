using Csharpik.Core.Models.BookModels;
using Csharpik.Core.Models.BookModels.dto;
using Csharpik.Core.Repositories.CommonRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharpik.Core.Services.BookServices
{
    public class AuthorService
    {
        private readonly IRepository<Author> _authorRepository;

        public AuthorService(IRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public List<AuthorDto> GetAll()
        {
            List<Author> authors = _authorRepository.GetAll();

            List<AuthorDto> dtoAuthors = ConvertListAuthorEntitiesToDtoList(authors);

            return dtoAuthors;
        }

        public AuthorDto GetById(int id)
        {
            Author author = _authorRepository.GetById(id);

            AuthorDto authorDto = AuthorEntityToDto(author);

            return authorDto;
        }

        //HACK: Author.GetById
        internal Author GetAuthorEntityById(int id)
        {
            return _authorRepository.GetById(id);
        }

        #region Entitiy To Dto
        private List<AuthorDto> ConvertListAuthorEntitiesToDtoList(List<Author> authors)
        {
            List<AuthorDto> dtoAuthors = new List<AuthorDto>();

            foreach (Author author in authors)
            {
                dtoAuthors.Add(AuthorEntityToDto(author));
            }

            return dtoAuthors;
        }

        private AuthorDto AuthorEntityToDto(Author author)
        {
            AuthorDto authorDto = new AuthorDto();
            authorDto.Id = author.Id;
            authorDto.Name = author.Name;
            authorDto.Biography = author.Biography;
            authorDto.BooksIdList = ConvertBookListToBookIdList(author.Books);

            return authorDto;
        }

        private List<int> ConvertBookListToBookIdList(List<Book> books)
        {
            List<int> BooksIdList = new List<int>();

            foreach (Book book in books)
            {
                BooksIdList.Add(book.Id);
            }

            return BooksIdList;
        }
        #endregion
    }
}
