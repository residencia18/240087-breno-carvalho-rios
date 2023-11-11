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

Console.WriteLine("Usando (int): " + numeroI);
Console.WriteLine("Usando Convert: " + numeroIConvert);

#endregion

#region Questão 4

Console.WriteLine("-----------------");
int x = 10;
int y = 3;

Console.WriteLine("A adição de x + y = {0} + {1} = {2}", x, y, (x + y));
Console.WriteLine("A subtração de x - y = {0} - {1} = {2}", x, y, (x - y));
Console.WriteLine("A multiplicação de x * y = {0} * {1} = {2}", x, y, (x * y));
Console.WriteLine("A divisão de x / y = {0} / {1} = {2:0.00}", x, y, ((float)x / y));

#endregion

#region Questão 5

Console.WriteLine("-----------------");
int a = 5;
int b = 8;

Console.WriteLine((a > b) ? "A é maior que B" : "A é menor que B");

#endregion

#region Questão 6

Console.WriteLine("-----------------");
string str1 = "Hello";
string str2 = "World";

Console.WriteLine((str1 == str2) ? "As strings são iguais" : "As strings são diferentes");

#endregion

#region Questão 7

Console.WriteLine("-----------------");
bool condicao1 = true;
bool condicao2 = false;

Console.WriteLine((condicao1 && condicao2) ? "As 2 condições são verdadeiras" : "Alguma condição não é verdadeira");

#endregion

#region Questão 8

Console.WriteLine("-----------------");
int num1 = 7;
int num2 = 3;
int num3 = 10;

Console.Write((num1 > num2) ? "num1 é maior do que num2" : "num1 é menor do que num2");
Console.Write(" e ");
Console.WriteLine((num3 == (num1 + num2)) ? "num3 é igual a num1 + num2" : "num3 é diferente de num1 + num2");

#endregion