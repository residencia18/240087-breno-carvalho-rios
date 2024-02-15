namespace ResTIConnect.Application.InputModels{
    public class NewSistemaInputModel{
        public required string Descricao { get; set; }
        public string? Tipo { get; set; }
        public int UsuarioId { get; set; }
        public int EventoId { get; set; }
    }
}
