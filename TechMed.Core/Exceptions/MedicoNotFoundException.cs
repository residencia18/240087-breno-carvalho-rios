namespace TechMed.Core.Exceptions;
public class MedicoNotFoundException : Exception
{
   public MedicoNotFoundException() :
      base("Médico não encontrado")
   {
   }
}
