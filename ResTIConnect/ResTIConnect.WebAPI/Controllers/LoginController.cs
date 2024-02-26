using Microsoft.AspNetCore.Mvc;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Infrastructure.Auth.Interfaces;

namespace ResTIConnect.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v0.1/login")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginInputModel loginInput)
        {
            var authenticatedUser = _loginService.Authenticate(loginInput);
            return Ok(authenticatedUser);
        }
    }
}
