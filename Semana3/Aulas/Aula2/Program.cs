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

float division(float n1, float n2){
    if(n2 == 0) {
        throw new Exception("Não é possível dividir por 0!");
    }

    return n1 / n2;
}

try {
    Console.WriteLine($"{2} / {1} = {division(2,1)}");
    Console.WriteLine($"{2} / {0} = {division(2,0)}");
} catch {
    Console.WriteLine($"Não é possível dividir por 0");
}

#endregion

#region Exercicio 3

float divisionE3(float n1, float n2){
    if(n2 == 0) {
        throw new Exception("Não é possível dividir por 0!");
    }

    return n1 / n2;
}

try {
    Console.WriteLine($"{2} / {1} = {divisionE3(2,1)}");
    Console.WriteLine($"{2} / {0} = {divisionE3(2,0)}");
} catch {
    Console.WriteLine($"Não é possível dividir por 0");
} finally {
    Console.WriteLine($"Finalmente alcançamos o finally!");    
}

#endregion

#region Exercicio 4

int simulatedOperation(int num){
    if(num < 0) {
        throw new Exception("Números negativos não são permitidos!");
    }

    return num;
}

try{
    Console.WriteLine(simulatedOperation(50));
    Console.WriteLine(simulatedOperation(-50));
} catch (Exception exception) {
    Console.WriteLine($"{exception.Message}");
}

#endregion