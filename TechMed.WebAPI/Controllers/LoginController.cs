using Microsoft.AspNetCore.Mvc;
using TechMed.Application.InputModels;
using TechMed.Application.Services.Interfaces;

namespace TechMed.WebAPI.Controllers;
[ApiController]
[Route("/api/v0.1/")]
public class LoginController : ControllerBase
{
    private readonly ILoginService _loginService;
    public LoginController(ILoginService loginService){
        _loginService = loginService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginInputModel user){
        var loginState = _loginService.Authenticate(user);
        return Ok(loginState);
    }
}
