using Csharpik.Core.Models.BookModels;
using Csharpik.Core.Models.Common;
using Csharpik.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Csharpik.Web.Controllers.BookControllers
{
    public class BookController : Controller
    {
        private readonly BookService _service;

        public BookController(BookService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            ObjectListDto dto = _service.GetAllBooks();

            List<Book> books = new List<Book>();

            if(dto.HttpCode == 200)
            {
                foreach (ICsharpikDtoObject obj in dto.ObjList)
                {
                    books.Add(obj as Book);
                }
            }

            return View(books);
        }
    }
}
