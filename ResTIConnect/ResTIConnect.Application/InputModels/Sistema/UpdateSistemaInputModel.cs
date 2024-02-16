namespace ResTIConnect.Application.InputModels
{
    public class UpdateSistemaInputModel
    {
        public required string Descricao { get; set; }
        public required string Tipo { get; set; }
        public required string Status { get; set; }
        public required string EnderecoEntrada { get; set; }
        public required string EnderecoSaida { get; set; }
        public required string Protocolo { get; set; }
        public required DateTimeOffset DataHoraInicioIntegracao { get; set; }
    }
}
