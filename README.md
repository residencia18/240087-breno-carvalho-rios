# Trilha .NET

![.NET_logo](https://upload.wikimedia.org/wikipedia/commons/thumb/7/7d/Microsoft_.NET_logo.svg/100px-Microsoft_.NET_logo.svg.png)

## Branch da Trilha .NET

Este branch é dedicado à trilha básica da Residência de Software, abrigando as atividades propostas realizadas pelos seguintes integrantes do grupo:

1. Alan Carlos - Repositório no GitHub [AlanSantos01](https://github.com/AlanSantos01)
2. Marcelo Cruz - Repositório no GitHub [Marckcruz](https://github.com/Marckcruz)
3. Daniel Coutinho - Repositório no GitHub [danielcoutinhoneto](https://github.com/danielcoutinhoneto)
4. Franklin - Repositório no GitHub [FranklinPereira2309](https://github.com/FranklinPereira2309)
5. Breno Rios - Repositório no GitHub [brenoriios](https://github.com/brenoriios)
6. Ezequiel Lobo - Repositório no GitHub [EzekLobo](https://github.com/EzekLobo)

## Objetivo

**Objetivo da Atividade:**
Introduzir os conceitos do Entity Framework Core e Clean Architecture. Além disso, estimular o trabalho em equipe através do Git Flow recomendado.

## Temp

Sobre o versionamento desta atividade:

- Esta atividade deve ser feita em um Repósitório/Branch referente ao projeto
TechMed desenvolvido em sala de aula.
- Crie uma branch “TechMed_Grupo” para essa atividade.
- Sigam o Git Flow discutido em sala:
    1. Protejam a Branch no GitHub;
    2. Para cada tarefa a ser realizada, criem um Branch com a seguinte assinatura: `DOTNET-P008/idtarefa-descricao_breve_da_tarefa`
    3. O desenvolvedor responsável pela tarefa irá fazer todos os commits referentes (e exclusivamente) a essa tarefa nesse Branch.
    4. Após finalizar a implementação, o desenvolvedor irá fazer um novo Merge de `TechMed_Grupo` (Origin) em seu Branch (Target) e realizar testes a fim de garantir que tudo ainda esteja funcionando.
    5. Em seguida, o desenvolvedor deve criar um Pull Request para o Branch `TechMed_Grupo`, que deverá ser aprovado por alguém da equipe.

### Orientações

Nesta atividade a sua equipe deve finalizar o projeto TechMed de acordo com o Diagrama de Classes abaixo. Fiquem à vontade para gerar novas classes e/ou interfaces no que facilitem a abstração. O importante é que sejam criados os enpoints listados na lista de tarefas da próxima seção.

#### Tarefas:

- **Id_01:**
    - Atualizar/criar a camada de Domínio de acordo com o Diagrama;

- **Id_02:**
    - Atualizar/criar a camada de Infraestrutura, com EF Core, de acordo com o Diagrama, dividindo as configurações dos modelos em arquivos separados do Context.

- **Id_03:**
    - Atualizar/criar a camada de Aplicação de acordo com o Diagrama.

- **Id_04:**
    - Atualizar/criar a camada da API de acordo com o Diagrama.

- **Id_05:**
    - Criar as Migrations na camada de Infraestrutura, lendo a string de conexão do
arquivo de configurações na camada de Web API.

- **Id_06:**
    - Criar os novos endpoints:
        - [GET] .../medico/{id}/atendimentos
            - todos atendimentos e exames com participação de um médico
        - [GET] .../paciente/{id}/atendimentos
            - todos atendimentos e exames com participação de um paciente
        - [GET] .../atendimentos/porPeriodo/{inicio}/{fim}
            - todos os atendimentos entre duas datas

#### Diagrama de Classes:

![Imagem do Diagrama de Classes](https://github.com/AlanSantos01/Trilha_dotnet/blob/TechMed_Grupo/Database/DiagramaDeClasses.png)
