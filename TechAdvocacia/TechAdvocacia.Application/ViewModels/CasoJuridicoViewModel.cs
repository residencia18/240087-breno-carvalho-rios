namespace TechAdvocacia.Application.ViewModels;
public class CasoJuridicoViewModel
{
    public int CasoJuridicoId { get; set; }
    public required string Status { get; set; }
    public required float ChanceSucesso { get; set; }
    public required AdvogadoViewModel Advogado { get; set; }
    public required ClienteViewModel Cliente { get; set; }
    public required ICollection<DocumentoViewModel> Documentos { get; set; }
}
