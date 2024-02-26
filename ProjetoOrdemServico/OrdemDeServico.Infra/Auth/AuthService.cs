using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using ResTIConnect.Infrastructure.Persistence;

namespace OrdemDeServico.Infra.Auth
{
    public class AuthService : IAuthService
    {
        private readonly OrdemDeServicoContext _context;

        public AuthService(OrdemDeServicoContext context)
        {
            _context = context;
        }

        public string ComputeSha256Hash(string text)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                return hash;
            }
        }

        public bool Login(string nome, string senha)
        {
            var senhaCriptografada = ComputeSha256Hash(senha);
            return _context.Usuarios.Any(u => u.NomeUsuario == nome && u.Senha == senhaCriptografada);
        }
    }
}
