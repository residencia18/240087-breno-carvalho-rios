using System.Security.Authentication;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;
using ResTIConnect.Domain.Exceptions;
using ResTIConnect.Infrastructure.Auth.Interfaces;
using ResTIConnect.Infrastructure.Context;

namespace ResTIConnect.Application.Services;
public class LoginService : ILoginService
{
    private readonly ResTIConnectDbContext _context;
    private readonly IAuthService _authService;
    public LoginService(ResTIConnectDbContext context, IAuthService authService) {
        _context = context;
        _authService = authService;
    }
    public LoginViewModel? Authenticate(LoginInputModel user)
    {
        var senhaCriptografada = _authService.ComputeSha256Hash(user.Password);

        var userDb = _context.Usuarios.FirstOrDefault(u =>
            u.Email == user.Email && u.Senha == senhaCriptografada
        ) ?? throw new InvalidCredentialException();

        var _perfis = _context.Perfis.Where(p => p.UsuarioId == userDb.UsuarioId).ToList();

        var token = _authService.GenerateJwtToken(user.Email, _perfis);
        return new LoginViewModel
        {
            Email = user.Email,
            Token = token
        };
    }
}
