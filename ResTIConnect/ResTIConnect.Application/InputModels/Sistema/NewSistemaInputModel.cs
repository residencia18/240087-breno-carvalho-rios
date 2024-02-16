namespace ResTIConnect.Application.InputModels
{
    public class NewSistemaInputModel
    {
        public required string Descricao { get; set; }
        public required string Tipo { get; set; }
        public required string Status { get; set; }
        public required string EnderecoEntrada { get; set; }
        public required string EnderecoSaida { get; set; }
        public required string Protocolo { get; set; }
        public required DateTimeOffset DataHoraInicioIntegracao { get; set; }
        public required List<int> UsuariosId { get; set; }
    }
}
