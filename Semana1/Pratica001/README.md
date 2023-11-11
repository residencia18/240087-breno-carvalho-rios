# Atividade Prática 001

**Com exceção da questão 1, todas as questões encontram-se implementadas no arquivo `Progam.cs`**

## Questão 1

### Como você pode verificar se o .NET SDK está corretamente instalado em seu sistema e como verificar as versões do .NET?

É possível usar o comando `dotnet --version` para ver qual versão do SDK está instalada no sistema. O resultado vai ser semelhante a esse, onde a segunda linha é a versão do SDK:

```
F:\TIC18\Modulo2\TIC18-Modulo2-DotNetT3\Semana1\Pratica001>dotnet --version
7.0.403
```

**Se o comando acima funcionar o .NET está instalado no seu sistema.**

Você também pode usar o comando `dotnet --list-sdks` para ver a lista de SDKs instaladas no sistema junto com o seu caminho de instalação. O seguinte resultado pode ser observado:

```
F:\TIC18\Modulo2\TIC18-Modulo2-DotNetT3\Semana1\Pratica001>dotnet --list-sdks                   
7.0.403 [C:\Program Files\dotnet\sdk]
```

Nesse caso há apenas um SDK, se mais SDKs estivessem instalados eles apareceriam na lista também.

Existe também o comando `dotnet --list-runtimes` que lista todas as runtimes do .NET instaladas no sistema, com nome e caminho de instalação. Exemplo de saída:

```
F:\TIC18\Modulo2\TIC18-Modulo2-DotNetT3\Semana1\Pratica001>dotnet --list-runtimes
Microsoft.AspNetCore.App 7.0.13 [C:\Program Files\dotnet\shared\Microsoft.AspNetCore.App]
Microsoft.NETCore.App 7.0.13 [C:\Program Files\dotnet\shared\Microsoft.NETCore.App]
Microsoft.WindowsDesktop.App 7.0.13 [C:\Program Files\dotnet\shared\Microsoft.WindowsDesktop.App]
```

### Como atualizar o .NET em seu sistema?

Para atualizar o .NET existe o comando `dotnet new update` que atualizará todos os modelos do .NET instalados no sistema.
Uma variação desse comando é o `dotnet new update --check-only` que apenas verifica se existem atualizações.

```
F:\TIC18\Modulo2\TIC18-Modulo2-DotNetT3\Semana1\Pratica001>dotnet new update             
Todos os pacotes de modelo estão atualizados.

F:\TIC18\Modulo2\TIC18-Modulo2-DotNetT3\Semana1\Pratica001>dotnet new update --check-only
Todos os pacotes de modelo estão atualizados.
```

### Como remover o .NET do seu sistema?

#### No Linux Ubuntu:

Para remover um SDK `apt-get remove dotnet-sdk-7.1`, onde `7.1` é a versão do SDK.

Ou para remover runtimes `apt-get remove dotnet-runtime-7.1`, onde `7.1` é a versão da runtime.

#### No Windows:

**É possível desinstalar diretamente pela lista de programas instalados no Windows.**

Alternativamente existe o [.NET uninstall tool](https://aka.ms/dotnet-core-uninstall-tool) que permite que você remova SDKs .NET e runtimes .NET do sistema usando o comando `dotnet-core-uninstall`. É possível ver a lista de SDKs e runtimes que podem ser desinstaladas usando o comando `dotnet-core-uninstall list`.

## Questão 2

Quais são os tipos de dados numéricos inteiros disponíveis no .NET? Dê
exemplos de uso para cada um deles através de exemplos.

## sbyte

Valores de `-128` até `127`.

Usado para armazenar valores inteiros bem pequenos e que possam ser negativos.

Exemplo:

Um menu com opções limitadas, como no exemplo abaixo onde queremos que o valor de `op` sempre esteja entre 1 e 3 ou seja -1 quando sair.

``` cs
sbyte op = 3;
Console.WriteLine("-------- Menu --------");
Console.WriteLine("1. Incluir");
Console.WriteLine("2. Excluir");
Console.WriteLine("3. Listar");
Console.WriteLine("-1. Sair");
Console.WriteLine("A opção que está selecionada é " + op);
```

## byte

Usado para armazenar valores inteiros bem pequenos e positivos.

Valores de `0` até `255`.

Um possível uso para o byte pode ser os parâmetros de uma cor RGB. No seguinte exemplo ela pode ser Branca, Preta, Azul, Verde ou Vermelha. Sempre com seus valores variando de 0 a 255:

``` cs
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

```
 
## short

Usado para armazenar valores inteiros um pouco maiores e que possam assumir valores negativos.

Valores de `-32.768` até `32.767`.

Um exemplo para o uso do short pode ser o gasto calórico de uma pessoa:

``` cs
short ingestaoCalorica = 2400;
short gastoCalorico = 2200;
short saldoCalorico = ingestaoCalorica - gastoCalorico;

Console.WriteLine("Ingestão Calórica: " + ingestaoCalorica);
Console.WriteLine("Gasto Calórico: " + ingestaoCalorica);
if(saldoCalorico > 0){
    Console.WriteLine("Você ingere mais calorias do que gasta, você vai engordar.");
} else {
    Console.WriteLine("Você ingere menos calorias do que gasta, você vai emagrecer.");
}
Console.WriteLine("Diferença calórica: " + saldoCalorico);
```

## ushort

Usado para armazenar valores inteiros um pouco maiores e positivos.

Valores de `0` até `65.535`.

Um exemplo de uso do ushort poderia ser o número de uma porta de servidor:

``` cs
ushort porta = 8080;

Console.WriteLine("A porta do servidor é " + porta);
```

## int
Usado para armazenar valores inteiros maiores do que `short` e que podem assumir valores negativos.

Valores de `-2.147.483.648` até `2.147.483.647`.

Um exemplo possível seria a variação dos casos de COVID no Brasil.

``` cs

int casos2022 = 14040000;
int casos2023 = 1660000;
int variacaoCasos = casos2023 - casos2022;

Console.WriteLine("A diferença de casos entre 2023 e 2022 é de " + variacaoCasos + " casos.");

```

## uint

Usado para armazenar valores inteiros como o `int`, mas que só são positivos.

Valores de `0` até `4.294.967.295`

Um exemplo de uso pode ser o guardar número de habitantes de cidades.

``` cs
uint popIlheus = 159923;
uint popIabuna = 185500;

Console.WriteLine("A população de Ilhéus é" + popIlheus);
Console.WriteLine("A população de Itabuna é" + popItabuna);
```

## long

Usado para armazenar valores inteiros maiores do que `int` e que podem assumir valores negativos.

Valores de `-9.223.372.036.854.775.808` até `9.223.372.036.854.775.807`.

Exemplo variação no número de vendas de produtos de uma grande empresa:

``` cs
long vendidos2022 = 4542400064;
long vendidos2023 = 2542402500;
long diferenca = vendidos2023 - vendidos2022;

Console.WriteLine("A diferença na venda dos produtos entre 2023 e 2022 foi: " diferenca + " produtos");

```

## ulong

Usado para armazenar valores inteiros maiores do que `int` e que são positivos.

Valores de `0` até `18.446.744.073.709.551.615`.

Exemplo guardar a população mundial:

``` cs
ulong popMundial = 8071250864;

Console.WriteLine("A população de mundial é" + popMundial);
```

## Questão 3

Implementada no `Program.cs`

Em uma situação onde é necessário apenas a parte inteira, sem considerar a parte fracionária faria uma conversão usando a conversão explícita:

``` cs
double numeroD = 128.55;
int numeroI = (int)(numeroD);
```

Em uma situação onde a parte fracionária importa, seria possível converter a variável utilizando a classe `Convert` e com isso também arredondar o valor na conversão:

``` cs
double numeroD = 128.55;
int numeroI = Convert.ToInt32(numeroD);
```

## Questão 4

Implementada no `Program.cs`

## Questão 5

Implementada no `Program.cs`

## Questão 6

Implementada no `Program.cs`

## Questão 7

Implementada no `Program.cs`

## Questão 8

Implementada no `Program.cs`