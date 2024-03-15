using Exercicio04.Classes.Interfaces;

namespace Exercicio04.Classes;

public class ServicoFabrica<T> where T : class, IServico, new()
{
    public static T NovaInstancia()
    {
        return new T();
    }
}
