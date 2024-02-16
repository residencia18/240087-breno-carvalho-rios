namespace ResTIConnect.Application.InputModels
{
    public class NewEventoInputModel
    {
        public required string Tipo { get; set; }
        public string? Descricao { get; set; }
        public required string Codigo { get; set; }
        public required string Conteudo { get; set; }
        public DateTimeOffset DataHoraOcorrencia { get; set; }
    }
}
