using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;
using TechMed.Domain.Entities;

namespace TechMed.Application.Services.InterfacesServices;

public interface IPacienteService : IBaseService<NewPacienteInputModel, PacienteViewModel, Paciente>
{
    public PacienteViewModel GetByCpf(int cpf);
}
