namespace TechAdvocacia.Core.Exceptions;
public class DocumentoNotFoundException : Exception
{
    public DocumentoNotFoundException() : base("Documento não encontrado!"){}
}
