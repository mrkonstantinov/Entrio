using System.Threading.Tasks;
using Entrio.Common.Commands;
using Entrio.Services.Identity.Services;
using Microsoft.AspNetCore.Mvc;

namespace Entrio.Services.Identity.Controllers
{
    [Route("")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthenticateUser command)
            => Json(await _userService.LoginAsync(command.Email, command.Password));
    }
}