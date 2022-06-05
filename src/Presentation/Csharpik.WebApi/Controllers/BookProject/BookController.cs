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

        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<BookDto> books = _service.GetAll();

            return Json(books);
        }

        [Route("GetById/{id}")]
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


        [Route("Update")]
        [HttpPut]
        public IActionResult Update(BookDto dto)
        {
            return Ok(_service.Update(dto));
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);

            return Ok("Book was succesfully deleted");
        }
    }
}
