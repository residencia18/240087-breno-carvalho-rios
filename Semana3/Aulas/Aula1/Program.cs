#region Exercicio 1

(string, int) createTuple(string nome, int idade){
    return (nome, idade);
}

Console.WriteLine($"{createTuple("Breno", 22)}");
Console.WriteLine($"{createTuple("João", 27)}");

#endregion

#region Exercicio 2

Func<int, int, int> sum = (a, b) => a + b;
Console.WriteLine($"Soma 22 com 27: {sum(22, 27)}");
Console.WriteLine($"Soma 18 com 32: {sum(18, 32)}");
Console.WriteLine($"Soma 9 com 12: {sum(9, 12)}");

#endregion