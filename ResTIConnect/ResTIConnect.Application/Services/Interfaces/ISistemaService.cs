
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.ViewModels;

namespace ResTIConnect.Application.Services.Interfaces
{
    public interface ISistemaService
    {
        public List<SistemaViewModel> GetAll();
        public SistemaViewModel? GetById(int id);
        public List<SistemaViewModel> GetUserById(int usuarioId);
        public List<SistemaViewModel> GetByEventoPeriodos(string tipoEvento, DateTime inicio);
        public void AdicionaSistemaAoEvento(int EventoId, int sistemaId);
        public int Create(NewSistemaInputModel Sistema);
    }
}
