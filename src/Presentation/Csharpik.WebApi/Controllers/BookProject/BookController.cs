using Csharpik.Core.Models.BookModels.dto;
using Csharpik.Core.Services.Interfaces.BookServices;
using Microsoft.AspNetCore.Mvc;

namespace Csharpik.WebApi.Controllers.BookProject
{

    [ApiController]
    [Route("Book")]
    public class BookController : Controller
    {
        private readonly IBookService<BookDto> _service;

        public BookController(IBookService<BookDto> service)
        {
            _service = service;
        }

        //HACK: Create ExceptionHandlerFilter
        //TODO: Create logger

        [Route("GetAllBooks")]
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            IEnumerable<BookDto> books = _service.GetAll();

            return Json(books);
        }

        [Route("GetBookById")]
        [HttpGet]
        public IActionResult GetBookById(int id)
        {
            BookDto bookDto = _service.GetById(id);

            return Json(bookDto);
        }
    }
}
