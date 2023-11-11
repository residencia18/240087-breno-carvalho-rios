#region Questão 02 - Exemplos

// sbyte
Console.WriteLine("Exemplo 1");
sbyte op = 3;
Console.WriteLine("-------- Menu --------");
Console.WriteLine("1. Incluir");
Console.WriteLine("2. Excluir");
Console.WriteLine("3. Listar");
Console.WriteLine("-1. Sair");
Console.WriteLine("A opção que está selecionada é " + op);

// byte
Console.WriteLine("-----------------");
Console.WriteLine("Exemplo 2");
byte red = 255;
byte green = 255;
byte blue = 255;

if(red == 255 && green == 255 && blue == 255) {
    Console.WriteLine("Cor Branca");
} else if(red == 0 && green == 0 && blue == 0) {
    Console.WriteLine("Cor Preta");
} else if(red == 255 && green == 0 && blue == 0) {
    Console.WriteLine("Cor Vermelha");
} else if(red == 0 && green == 255 && blue == 0) {
    Console.WriteLine("Cor Verde");
} else if(red == 0 && green == 0 && blue == 255) {
    Console.WriteLine("Cor Azul");
} else {
    Console.WriteLine("Não conheço essa cor");
}

// short
Console.WriteLine("-----------------");
Console.WriteLine("Exemplo 3");
short ingestaoCalorica = 2000;
short gastoCalorico = 2500;
short saldoCalorico = (short)(ingestaoCalorica - gastoCalorico);

Console.WriteLine("Ingestão Calórica: " + ingestaoCalorica);
Console.WriteLine("Gasto Calórico: " + gastoCalorico);
Console.WriteLine("Diferença calórica: " + saldoCalorico);
if(saldoCalorico > 0){
    Console.WriteLine("Você ingere mais calorias do que gasta, você vai engordar.");
} else {
    Console.WriteLine("Você ingere menos calorias do que gasta, você vai emagrecer.");
}

// ushort
Console.WriteLine("-----------------");
Console.WriteLine("Exemplo 4");
ushort porta = 8080;

Console.WriteLine("A porta do servidor é " + porta);

// int
Console.WriteLine("-----------------");
Console.WriteLine("Exemplo 5");
int casos2022 = 14040000;
int casos2023 = 1660000;
int variacaoCasos = casos2023 - casos2022;

Console.WriteLine("A diferença de casos entre 2023 e 2022 é de " + variacaoCasos + " casos.");

// uint
Console.WriteLine("-----------------");
Console.WriteLine("Exemplo 6");
uint popIlheus = 159923;
uint popItabuna = 185500;

Console.WriteLine("A população de Ilhéus é " + popIlheus);
Console.WriteLine("A população de Itabuna é " + popItabuna);

// long
Console.WriteLine("-----------------");
Console.WriteLine("Exemplo 7");
long vendidos2022 = 4542400064;
long vendidos2023 = 2542402500;
long diferenca = vendidos2023 - vendidos2022;

Console.WriteLine("A diferença na venda dos produtos entre 2023 e 2022 foi: " + diferenca + " produtos vendidos");

// ulong
Console.WriteLine("-----------------");
Console.WriteLine("Exemplo 8");
long popMundial = 8071250864;

Console.WriteLine("A população de mundial é " + popMundial);

#endregion

#region Questão 3

Console.WriteLine("-----------------");
double numeroD = 128.55;
int numeroI =(int)(numeroD);
int numeroIConvert = Convert.ToInt32(numeroD);

Console.WriteLine(numeroI);
Console.WriteLine(numeroIConvert);

#endregion