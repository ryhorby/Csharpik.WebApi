using Csharpik.Core.Models.BookModels.dto;
using Csharpik.Core.Services.Interfaces.BookServices;
using Microsoft.AspNetCore.Mvc;

namespace Csharpik.WebApi.Controllers.BookProject
{

    [ApiController]
    [Route("Author")]
    public class AuthorController : Controller
    {
        private readonly IBookService<AuthorDto> _service;

        public AuthorController(IBookService<AuthorDto> service)
        {
            _service = service;
        }


        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<AuthorDto> authors = _service.GetAll();

            return Json(authors);
        }


        [Route("GetById/{id}")]
        [HttpGet]
        public IActionResult GetById(int id)
        {
            AuthorDto authorDto = _service.GetById(id);

            return Json(authorDto);
        }


        [Route("Create")]
        [HttpPost]
        public IActionResult Create(AuthorDto dto)
        {
            _service.Create(dto);

            return Ok("Author was succesfully added");
        }


        [Route("Update")]
        [HttpPut]
        public IActionResult Update(AuthorDto dto)
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
