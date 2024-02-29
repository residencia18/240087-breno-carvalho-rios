using OrdemDeServico.Application.InputModels;
using OrdemDeServico.Application.Services.Interfaces;
using OrdemDeServico.Application.ViewModels;
using OrdemDeServico.Domain.Exceptions;
using OrdemDeServico.Infra.Auth;
using ResTIConnect.Infrastructure.Persistence;

namespace OrdemDeServico.Application.Services;

public class LoginService : ILoginService
{
    private readonly IAuthService _authService;
    private readonly OrdemDeServicoContext _context;
    public LoginService(IAuthService authService, OrdemDeServicoContext context) {
        _authService = authService;
        _context = context;
    }
    public LoginViewModel? Authenticate(NewLoginInputModel user)
    {
        var senhaCriptografada = _authService.ComputeSha256Hash(user.Senha);

        var userDb = _context.Usuarios.FirstOrDefault(u =>
            u.NomeUsuario == user.NomeUsuario && u.Senha == senhaCriptografada
        ) ?? throw new InvalidCredentialsException();

        var token = _authService.GenerateJwtToken(user.NomeUsuario, "Admin");
        return new LoginViewModel
        {
            NomeUsuario = user.NomeUsuario,
            Token = token
        };
    }
}