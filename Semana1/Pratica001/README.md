# Atividade Prática 001

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