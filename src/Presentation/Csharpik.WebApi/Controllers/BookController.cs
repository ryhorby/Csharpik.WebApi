using Csharpik.Core.Models.BookModels.dto;
using Csharpik.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

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

        //HACK: Create ExceptionHandlerFilter
        //TODO: Create logger

        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            List<BookDto> books = _service.GetAll();

            return Json(books);
        }

        [Route("GetById")]
        [HttpGet]
        public IActionResult GetBookById(int id)
        {
            BookDto bookDto = _service.GetById(id);

            return Json(bookDto);
        }


        [Route("Create")]
        [HttpPost]
        public IActionResult CreateBook(BookDto bookDto)
        {
            _service.Create(bookDto);

            return Json("succeeded");
        }
    }
}
