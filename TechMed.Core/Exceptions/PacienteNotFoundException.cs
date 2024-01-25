namespace TechMed.Core.Exceptions;
public class PacientNotFoundException : Exception
{
   public PacientNotFoundException() :
      base("Paciente não encontrado")
   {
   }
}
