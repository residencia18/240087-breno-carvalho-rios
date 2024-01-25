using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;

namespace TechMed.Application.Services.Interfaces;
public interface IPacienteService
{
    public int Create(NewPacienteInputModel paciente);
    public void Update(int id, NewPacienteInputModel paciente);
    public void Delete(int id);
    public PacienteViewModel? GetById(int id);
    public PacienteViewModel? GetByCpf(string cpf);
    public List<PacienteViewModel> GetAll();
}
