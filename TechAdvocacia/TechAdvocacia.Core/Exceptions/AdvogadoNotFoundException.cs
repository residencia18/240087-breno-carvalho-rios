namespace TechAdvocacia.Core.Exceptions;
public class AdvogadoNotFoundException : Exception
{
    public AdvogadoNotFoundException() : base("Advogado não encontrado!") { }
}
