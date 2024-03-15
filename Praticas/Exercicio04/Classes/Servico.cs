using Exercicio04.Classes.Interfaces;

namespace Exercicio04.Classes;
class Servico : IServico
{
    public void Executar()
    {
        Console.WriteLine($"Executando servico...");
    }
}
