
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.ViewModels;
using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Application.Services.Interfaces
{
    public interface ISistemaService :IBaseService<NewSistemaInputModel, SistemaViewModel, Sistema>
    {
        List<SistemaViewModel> GetByEventoPeriodos(string tipoEvento, DateTime inicio);
        void AdicionaEventoAoSistema(int eventoId, int sistemaId);
    }
}
