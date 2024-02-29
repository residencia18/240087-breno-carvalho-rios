using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Infrastructure.Auth.Interfaces;

public interface IAuthService
{
    string ComputeSha256Hash(string pass);
    string GenerateJwtToken(string username, ICollection<Perfil> perfis);
}
