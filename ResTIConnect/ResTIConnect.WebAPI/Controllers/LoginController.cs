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
        private readonly IAuthService _authService;

        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginInputModel loginInput)
        {
            var loginSucceeded = _authService.Login(loginInput.Email, loginInput.Password);
            if (loginSucceeded)
            {
                return Ok(new { Mensagem = "Login bem-sucedido." });
            }
            else
            {
                return Unauthorized(new { Mensagem = "Login falhou. E-mail ou senha inválidos." });
            }
        }
    }
}
