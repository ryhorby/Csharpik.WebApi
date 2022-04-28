using Csharpik.Core.Models.Common;

namespace Csharpik.Core.Repositories
{
    public interface IBookRepository
    {
        public ObjectDto GetBookById(int id);
        public ObjectListDto GetAllBooks();
    }
}
