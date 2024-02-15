namespace ResTIConnect.Domain.Exceptions
{
    public class SistemaNotFoundException: Exception
    {
        public SistemaNotFoundException() :
           base("Sistema não encontrado.")
        {
        }
    }
}
