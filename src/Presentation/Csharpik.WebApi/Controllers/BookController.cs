using Csharpik.Core.Models.BookModels.dto;
using Csharpik.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Csharpik.WebApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {
        private readonly BookService _service;

        public BookController(BookService service)
        {
            _service = service;
        }

        [Route("All")]
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            List<BookDto> books = _service.GetAllBooks();

            return Ok(books);
        }
    }
}
