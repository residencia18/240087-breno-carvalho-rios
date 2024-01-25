using TechMed.Application.ViewModels;

namespace TechMed.Application.Services.Interfaces;
public interface IAtendimentoService
{
    public List<AtendimentoViewModel> GetAll();
}
