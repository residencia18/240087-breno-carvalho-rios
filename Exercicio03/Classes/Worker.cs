namespace Exercicio03.Classes;

class Worker
{
    public string NomeWorker { get; set; }

    public Worker(string nomeWorker)
    {
        NomeWorker = nomeWorker;
    }
    public void Work()
    {
        Random rand = new Random();
        for (int i = 1; i <= 10; i++)
        {
            Thread.Sleep(rand.Next(500, 3000));
            Console.WriteLine($"{NomeWorker} - Passo {i}");
        }
    }
}
