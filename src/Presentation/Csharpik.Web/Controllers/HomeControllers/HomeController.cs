using Microsoft.AspNetCore.Mvc;

namespace Csharpik.Web.Controllers.HomeControllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
