namespace OrdemDeServico.Infra.Auth;

public interface IAuthService
{
    string GenerateJwtToken(string username, string role);
    string ComputeSha256Hash(string password);
}