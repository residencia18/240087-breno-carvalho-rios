
namespace ResTIConnect.Application.ViewModels
{
    public class SistemaViewModel
    {
        public int SistemaId { get; set; }
        public required string Descricao { get; set; }
        public required string Tipo { get; set; }
        public required string Status { get; set; }
        public required string EnderecoEntrada { get; set; }
        public required string EnderecoSaida { get; set; }
        public required string Protocolo { get; set; }
        public required DateTimeOffset DataHoraInicioIntegracao { get; set; }
        public required List<UsuarioViewModel> Usuarios { get; set; }
        public required List<EventoViewModel> Eventos { get; set; }
    }
}
