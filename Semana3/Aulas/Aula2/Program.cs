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

#region Exercicio 2

float divisao(float n1, float n2){
    if(n2 == 0) {
        throw new Exception("Não é possível dividir por 0!");
    }

    return n1 / n2;
}

try {
    Console.WriteLine($"{2} / {1} = {divisao(2,1)}");
    Console.WriteLine($"{2} / {0} = {divisao(2,0)}");
} catch {
    Console.WriteLine($"Não é possível dividir por 0");
}

#endregion