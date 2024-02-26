using Microsoft.AspNetCore.Mvc;
using OrdemDeServico.Application.InputModels;
using OrdemDeServico.Infra.Auth;


namespace OrdemDeServico.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IAuthService _authService;

        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginInputModel loginInput)
        {
            var loginSucceeded = _authService.Login(loginInput.NomeUsuario, loginInput.Password);
            if (loginSucceeded)
            {
                return Ok(new { Mensagem = "Login bem-sucedido." });
            }
            else
            {
                return Unauthorized(new { Mensagem = "Login falhou. Nome ou senha inválidos." });
            }
        }
    }
}
