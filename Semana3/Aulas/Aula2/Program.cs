#region Exercicio 1

Console.WriteLine($"Insira um número: ");
string input = Console.ReadLine() ?? "0";
int num;
try {
    num = int.Parse(input);
} catch {
    Console.WriteLine("Por favor digite um número válido");
}

#endregion