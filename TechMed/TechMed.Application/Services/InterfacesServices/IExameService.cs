using TechMed.Application.InputModels;

namespace TechMed.Application.Services.InterfacesServices;

public interface IExameService
{
    public List<ExameViewModel> GetAll();
    public int Create(int atendimentoId, NewExameInputModel exame);
    public void Update(int id, NewExameInputModel exame);
    public void Delete(int id);

}
