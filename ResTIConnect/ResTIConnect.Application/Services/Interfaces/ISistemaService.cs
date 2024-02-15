
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.ViewModels;
using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Application.Services.Interfaces
{
    public interface ISistemaService :IBaseService<NewSistemaInputModel, SistemaViewModel, Sistema>
    {
        public List<SistemaViewModel> GetByEventoPeriodos(string tipoEvento, DateTime inicio);
        public void AdicionaSistemaAoEvento(int EventoId, int sistemaId);
    }
}
