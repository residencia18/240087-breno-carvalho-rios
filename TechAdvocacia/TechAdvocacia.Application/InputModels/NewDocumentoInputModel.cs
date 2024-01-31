using TechAdvocacia.Core.Entities;

namespace TechAdvocacia.Application.InputModels;
public class NewDocumentoInputModel
{
    public required string Descricao { get; set; }
    public int CasoJuridicoId { get; set; }
}
