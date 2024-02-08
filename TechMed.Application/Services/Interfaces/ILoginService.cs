using TechMed.Application.InputModels;

namespace TechMed.Application.Services.Interfaces;
public interface ILoginService
{
    LoginViewModel? Authenticate(LoginInputModel user);
}
