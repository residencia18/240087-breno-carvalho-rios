var task1 = Task.Run(async () => await DoWorkAsync("Tarefa 1", 5, 500));
var task2 = Task.Run(async () => await DoWorkAsync("Tarefa 2", 7, 1000));

await Task.WhenAll(task1, task2);

Console.WriteLine("As duas tarefas foram concluídas.");

static async Task DoWorkAsync(string nome, int numeroIteracoes, int tempoEspera)
{
    for (int i = 1; i <= numeroIteracoes; i++)
    {
        await Task.Delay(TimeSpan.FromMilliseconds(tempoEspera));
        Console.WriteLine($"{nome} - Iteração {i}/{numeroIteracoes}");
    }
}
