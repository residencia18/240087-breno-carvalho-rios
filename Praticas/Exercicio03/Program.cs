enum Exercicio
{
    Academia,
    Luta,
    Corrida
};

public class App
{
    public static void Main()
    {
        Console.WriteLine($"Texto do exercício {Exercicio.Luta}");
        Console.WriteLine($"Texto do exercício {Exercicio.Corrida}");
        Console.WriteLine($"Texto do exercício {Exercicio.Academia}");
    }
}
