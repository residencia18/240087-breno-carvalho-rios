using TechMed.Application.InputModels;
using TechMed.Domain.Entities;

namespace TechMed.Application.Services.InterfacesServices;

public interface IExameService : IBaseService<NewExameInputModel, ExameViewModel, Exame>
{
    List<ExameViewModel> GetByAtendimentoId(int id);
}
