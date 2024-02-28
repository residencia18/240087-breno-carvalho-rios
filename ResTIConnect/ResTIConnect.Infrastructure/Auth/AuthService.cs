using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ResTIConnect.Domain.Entities;
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

    public string GenerateJwtToken(string username, ICollection<Perfil> perfis)
    {
        var issuer = _configuration["Jwt:Issuer"];
        var audience = _configuration["Jwt:Audience"];
        var key = _configuration["Jwt:Key"] ?? "";
        //cria uma chave utilizando criptografia simétrica
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        //cria as credenciais do token
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = perfis
            .Select(perfil => perfil.Permissoes)
            .Select(permissoes => new Claim(ClaimTypes.Role, permissoes));

        claims.Append(new Claim("username", username));
        
        var token = new JwtSecurityToken( //cria o token
           issuer: issuer, //emissor do token
           audience: audience, //destinatário do token
           claims: claims, //informações do usuário
           expires: DateTime.Now.AddMinutes(30), //tempo de expiração do token
           signingCredentials: credentials //credenciais do token
        );


        var tokenHandler = new JwtSecurityTokenHandler(); //cria um manipulador de token

        var stringToken = tokenHandler.WriteToken(token);

        return stringToken;
    }

}
