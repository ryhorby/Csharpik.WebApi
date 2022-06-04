using Csharpik.Core.Models.BookModels;
using Csharpik.Core.Services.Interfaces.BookServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Csharpik.WebApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AuthorController : Controller
    {
        private readonly IBookService<Author> _service;

        public AuthorController(IBookService<Author> service)
        {
            _service = service;
        }

        //HACK: Create ExceptionHandlerFilter
        //TODO: Create logger

        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAllAuthors()
        {
            IEnumerable<Author> authors = _service.GetAll();

            return Json(authors);

        }

        [Route("GetById")]
        [HttpGet]
        public IActionResult GetAuthorById(int id)
        {
            Author authorDto = _service.GetById(id);

            return Json(authorDto);
        }
    }
}
