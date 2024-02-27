namespace MvcMovie.Auth;
public interface IAuthService
{
    string ComputeSha256Hash(string pass);
    string GenerateJwtToken(string username, string role);
}
