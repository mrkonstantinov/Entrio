using Microsoft.AspNetCore.Mvc;

namespace Entrio.Services.Identity.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Get() => Content("Hello from Actio.Services.Identity API!");
    }
}