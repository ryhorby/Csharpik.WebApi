using Csharpik.Core.Models.User.dto;
using Csharpik.Core.Services.Interfaces.RegisterServices;
using Microsoft.AspNetCore.Mvc;

namespace Csharpik.WebApi.Controllers.RegistrationProject
{
    [ApiController]
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IRegisterService _registorService;

        public AuthController(IConfiguration configuration, IRegisterService registorService)
        {
            _registorService = registorService;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public IActionResult Register(UserDto request)
        {
            if (request.Login == string.Empty | request.Password == string.Empty)
                return BadRequest("Login or password is empty");

            _registorService.Create(request);

            return Created("/auth/register", request);
        }

        [HttpPost("login")]
        public ActionResult<string> Login(UserDto request)
        {
            return Ok(_registorService.Login(request));
        }
    }
}
