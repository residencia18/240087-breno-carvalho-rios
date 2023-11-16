# region Exemplo - Laços e Condicionais

string[] colecao = {"Item 1", "Item 2", "Item 3", "Item 4"};

foreach(string item in colecao) {
    Console.WriteLine(item);
}

#endregion

#region Exercício 1

for(int i = 0; i <= 30; i++){
    if(i % 3 == 0 || i % 4 == 0){
        Console.WriteLine(i);
    }
}

#endregion

#region Exercício 2

int fibN2 = 0, fibN1 = 1, fibN = fibN2 + fibN1;
Console.WriteLine(fibN2);
Console.WriteLine(fibN1);

for(int i = fibN1; fibN <= 100; i++){
    fibN = fibN1 + fibN2;

    fibN2 = fibN1;
    fibN1 = fibN;

    Console.WriteLine(fibN);
}

#endregion

#region Exercício 3

for(int i = 1; i <= 8; i++){
    for(int j = 1; j <= i; j++){
        Console.Write(i * j + " ");
    }
    Console.WriteLine();
}

#endregion