namespace ResTIConnect.Infrastructure.Auth.Interfaces;

public interface IAuthService
{
    string ComputeSha256Hash(string pass);
    bool Login(string email, string senha);
}
