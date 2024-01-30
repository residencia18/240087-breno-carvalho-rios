namespace TechAdvocacia.Application.InputModels;
public class NewCasoJuridicoInputModel
{
    public required string Status { get; set; }
    public required float ChanceSucesso { get; set; }
    public required int AdvogadoId { get; set; }
    public required int ClienteId { get; set; }
}
