using Microsoft.AspNetCore.Mvc;

namespace Entrio.Services.Entries.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Get() => Content("Hello from Entrio.Services.Entries API!");
    }
}