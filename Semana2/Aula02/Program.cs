#region Readline Example

Console.WriteLine($"Informe uma string");
string? name = Console.ReadLine();
Console.WriteLine($"Olá {(String.IsNullOrWhiteSpace(name) ?  "desconhecido(a)" : name)}!");

#endregion

#region String Examples

string? newString = name.Substring(0, name.Length / 2);
Console.WriteLine($"A string foi {newString}");

#endregion

#region Array Examples

string[] splittedString = name.Split(' ');

foreach (string word in splittedString){
    Console.WriteLine($"{word}");
}

#endregion

#region List Examples



#endregion

#region Exercício 1

string date = "25/10/2023";
string[] splittedDate = date.Split('/');
Console.WriteLine($"Dia: {splittedDate[0]}");
Console.WriteLine($"Mês: {splittedDate[1]}");
Console.WriteLine($"Ano: {splittedDate[2]}");

#endregion

#region Exercício 2

int[] numeros = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
foreach(int numero in numeros){
    if(numero % 2 == 0){
        Console.WriteLine($"{numero}");
    }
}

#endregion

#region Exexrcício 3

List<string> cidades = new() {
    "Ilhéus",
    "Itabuna",
    "Salvador"
};

cidades.Add("São Paulo");
cidades.Add("Rio de Janeiro");

foreach(string cidade in cidades.FindAll(x => x.StartsWith("S"))){
    Console.WriteLine(cidade);
}

#endregion

#region Exercício 4

DateTime today = DateTime.Now;
DateTime future = new DateTime(2024, 1, 1, 12, 0, 0);

double dateDifference = Math.Round(future.Subtract(today).TotalMinutes, 0);

Console.WriteLine($"Diferença de {dateDifference} minutos");

#endregion