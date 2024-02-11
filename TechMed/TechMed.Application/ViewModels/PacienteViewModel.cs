namespace TechMed.Application.ViewModels;

public class PacienteViewModel
{
    public int PacienteId { get; set; }
    public required string Nome { get; set; }
    public required string Cpf { get; set; }
    public required DateTimeOffset DataNascimento { get; set; }

}
