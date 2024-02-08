using TechMed.Application.InputModels;
using TechMed.Application.Services.Interfaces;
using TechMed.Infrastructure.Auth;

namespace TechMed.Application.Services;
public class LoginService : ILoginService
{
    private readonly IAuthService _authService;
    public LoginService(IAuthService authService) {
        _authService = authService;
    }
    public LoginViewModel? Authenticate(LoginInputModel user)
    {
        var passHashed = _authService.ComputeSha256Hash(user.Password);
        var admHashed = _authService.ComputeSha256Hash("admin");

        var token = _authService.GenerateJwtToken(user.Username, "admin");

        if (user.Username == "admin" && passHashed == admHashed)
        {
            return new LoginViewModel
            {
                Username = user.Username,
                Token = token
            };
        }

        return null;
    }
}
