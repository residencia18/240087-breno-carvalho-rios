using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using ResTIConnect.Infrastructure.Auth.Interfaces;
using ResTIConnect.Infrastructure.Context;

namespace ResTIConnect.Infrastructure.Auth;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
     private readonly ResTIConnectDbContext _context;

    public AuthService(IConfiguration configuration, ResTIConnectDbContext context)

    {
        _configuration = configuration;
        _context = context;
    }

    public string ComputeSha256Hash(string pass)
    {
        using (var sha256 = SHA256.Create())
        {
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(pass));
            var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            return hash;
        }
    }

    public bool Login(string email, string senha)
    {
        var senhaCriptografada = ComputeSha256Hash(senha);
        return _context.Usuarios.Any(u => u.Email == email && u.Senha == senhaCriptografada);
    }
}
