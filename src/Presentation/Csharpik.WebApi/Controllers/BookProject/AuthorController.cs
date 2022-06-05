using Csharpik.Core.Models.BookModels;
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

        //HACK: Create ExceptionHandlerFilter
        //TODO: Create logger

        [Route("GetAllAuthor")]
        [HttpGet]
        public IActionResult GetAllAuthors()
        {
            IEnumerable<AuthorDto> authors = _service.GetAll();

            return Json(authors);

        }

        [Route("GetAuthorById")]
        [HttpGet]
        public IActionResult GetAuthorById(int id)
        {
            AuthorDto authorDto = _service.GetById(id);

            return Json(authorDto);
        }
    }
}
