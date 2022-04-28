using Csharpik.Core.Models.BookModels;
using Csharpik.Core.Models.BookModels.dto;
using Csharpik.Core.Services.BookServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Csharpik.WebApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AuthorController : Controller
    {
        private readonly AuthorService _service;

        public AuthorController(AuthorService service)
        {
            _service = service;
        }

        //HACK: Create ExceptionHandlerFilter
        //TODO: Create logger

        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAllAuthors()
        {
            List<AuthorDto> authors = _service.GetAll();

            return Json(authors);

        }

        [Route("GetById")]
        [HttpGet]
        public IActionResult GetAuthorById(int id)
        {
            AuthorDto authorDto = _service.GetById(id);

            return Json(authorDto);
        }
    }
}
