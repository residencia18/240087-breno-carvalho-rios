using System.Security.Cryptography;
using System.Text;

namespace OrdemDeServico.Infra.Auth;
public class AuthService : IAuthService
{
    public string ComputeSha256Hash(string text)
    {
        using (var sha256 = SHA256.Create())
        {
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
            var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            return hash;
        }
    }
}
