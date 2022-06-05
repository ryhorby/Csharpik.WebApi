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

        [Route("GetBooks")]
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<BookDto> books = _service.GetAll();

            return Json(books);
        }

        [Route("GetById")]
        [HttpGet]
        public IActionResult GetById(int id)
        {
            BookDto bookDto = _service.GetById(id);

            return Json(bookDto);
        }

        [Route("Create")]
        [HttpPost]
        public IActionResult Create(BookDto dto)
        {
            _service.Create(dto);

            return Ok("Book was succesfully added");
        }
    }
}
