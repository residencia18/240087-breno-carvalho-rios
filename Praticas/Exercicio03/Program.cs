enum Exercicio
{
    Academia = 1,
    Luta = 2,
    Corrida = 3
};

public class App
{
    public static void Main()
    {
        Console.WriteLine($"Opções de exercício:");

        int i = 1;
        foreach (var exercicio in Enum.GetValues<Exercicio>())
        {
            Console.WriteLine($"{i}. {exercicio}");
            i++;
        }


        try
        {
            int opcao = int.Parse(Console.ReadLine() ?? "");
            Console.WriteLine($"Exercício escolhido: {Enum.GetName(typeof(Exercicio), opcao)}");
        }
        catch (FormatException)
        {
            Console.WriteLine($"É necessário informar um número valido");
        }
    }
}
