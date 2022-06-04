using Csharpik.Core.Models.BookModels;
using Csharpik.Core.Services.Interfaces.BookServices;
using Microsoft.AspNetCore.Mvc;

namespace Csharpik.WebApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {
        private readonly IBookService<Book> _service;

        public BookController(IBookService<Book> service)
        {
            _service = service;
        }

        //HACK: Create ExceptionHandlerFilter
        //TODO: Create logger

        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            IEnumerable<Book> books = _service.GetAll();

            return Json(books);
        }

        [Route("GetById")]
        [HttpGet]
        public IActionResult GetBookById(int id)
        {
            Book bookDto = _service.GetById(id);

            return Json(bookDto);
        }
    }
}
