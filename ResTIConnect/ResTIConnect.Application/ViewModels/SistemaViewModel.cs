
namespace ResTIConnect.Application.ViewModels
{
    public class SistemaViewModel
    {
        public int SistemaId { get; set; }
        public required string Descricao { get; set; }
        public string? Tipo { get; set; }
        public List<UsuarioViewModel>? Users { get; set; } = new List<UsuarioViewModel>();
        //public List<EventoViewModel>? Eventos { get; set; } = new List<EventoViewModel>();
    }
}
