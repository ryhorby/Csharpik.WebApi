using Csharpik.Core.Models.BookModels;
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

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Book> books = _service.GetAllBooks();

            return View(books);
        }
    }
}
