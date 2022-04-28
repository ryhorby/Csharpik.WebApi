using Csharpik.Core.Models.BookModels.dto;

namespace Csharpik.Core.Repositories
{
    public interface IBookRepository
    {
        public List<BookDto> GetAllBooks();
    }
}
