namespace TechMed.Domain.Exceptions;

public class ExameNotFoundException : Exception
{
    public ExameNotFoundException() : base("Exame não encontrado") { }
}
