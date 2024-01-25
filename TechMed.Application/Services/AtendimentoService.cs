using TechMed.Application.Services.Interfaces;
using TechMed.Application.ViewModels;
using TechMed.Infrastructure.Persistence.Interfaces;

namespace TechMed.Application.Services;
public class AtendimentoService : IAtendimentoService
{
    private readonly ITechMedContext _context;
    public AtendimentoService(ITechMedContext context){
        _context = context;
    }
    public List<AtendimentoViewModel> GetAll()
    {
        return _context.AtendimentosCollection.GetAll().Select(atendimento => new AtendimentoViewModel{
            AtendimentoId = atendimento.AtendimentoId,
            DataHora = atendimento.DataHora,
            Medico = new MedicoViewModel{
                MedicoId = atendimento.Medico.MedicoId,
                Nome = atendimento.Medico.Nome,
            },
            Paciente = new PacienteViewModel{
                PacienteId = atendimento.Paciente.PacienteId,
                Nome = atendimento.Paciente.Nome
            }
        }).ToList();
    }
}
