namespace ResTIConnect.Domain.Exceptions
{
    public class PerfilNotFoundException: Exception
    {
        public PerfilNotFoundException() :
           base("O perfil selecionado não foi encontrado.")
        {
        }
    }
}
