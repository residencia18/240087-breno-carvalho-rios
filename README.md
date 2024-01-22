# Trilha .NET

![.NET_logo](https://upload.wikimedia.org/wikipedia/commons/thumb/7/7d/Microsoft_.NET_logo.svg/100px-Microsoft_.NET_logo.svg.png)

## Repositório da Trilha .NET

Este repositório é dedicado à trilha básica da Residência de Software, abrigando as atividades propostas realizadas pelos seguintes integrantes do grupo:

1. Alan Carlos - Repositório no GitHub [AlanSantos01](https://github.com/AlanSantos01)
2. Marcelo Cruz - Repositório no GitHub [Marckcruz](https://github.com/Marckcruz)
3. Daniel Coutinho - Repositório no GitHub [danielcoutinhoneto](https://github.com/danielcoutinhoneto)
4. Franklin - Repositório no GitHub [FranklinPereira2309](https://github.com/FranklinPereira2309)
5. Breno Rios - Repositório no GitHub [brenoriios](https://github.com/brenoriios)
6. Ezequiel Lobo - Repositório no GitHub [EzekLobo](https://github.com/EzekLobo)

## Objetivo

**Objetivo Geral:**
Introduzir os conceitos do Entity Framework Core. Além disso, praticar a modelagem dos dados, relacionamentos entre as entidades e as consultas através do Entity Framework Core. Estimular o trabalho em equipe através do Git Flow recomendado.

### Atividade em Grupo

**Descrição:**
Atividade em Grupo
Sobre o versionamento desta atividade:
- Esta atividade deve ser feita no Repositório/Branch referente ao projeto pessoal da equipe.
- Na branch “EntityFramework” utilizada na atividade anterior (PI-0004).
- Sigam o Git Flow discutido em sala:
  1. Protejam a Branch no GitHub;
  2. Para cada tarefa a ser realizada, criem um Branch com a seguinte assinatura: `DOTNET-P005/idtarefa-descricao_breve_da_tarefa`.
  3. O desenvolvedor responsável pela tarefa irá fazer todos os commits referentes (e exclusivamente) a essa tarefa nesse Branch.
  4. Após finalizar a implementação, o desenvolvedor irá fazer um novo Merge de `EntityFramework` (Origin) em seu Branch (Target) e realizar testes a fim de garantir que tudo ainda esteja funcionando.
  5. Em seguida, o desenvolvedor deve criar um Pull Request para o Branch `EntityFramework`, que deverá ser aprovado por alguém da equipe.

#### Orientações:

Nessa tarefa nossa equipe deve analisar as entidades modeladas na atividade anterior e identificar os relacionamentos. Nosso projeto deve possuir, ao menos, um relacionamento de cada tipo visto nas aulas: (1) um para um, (2) um para muitos (3) muitos para muitos. Caso a modelagem anterior não possua os relacionamentos, devemos repensar o modelo e fazer as mudanças necessárias. 

##### Tarefas:

- **Id_01:**
  - Criar um projeto do tipo “Class Library” para a prática. Esse projeto representará a camada de Entidades na Arquitetura do projeto.

- **Id_02:**
  - No projeto criado anteriormente, modelar as entidades com relacionamento um para um e fazer o Migration inicial.

- **Id_03:**
  - Modelar as entidades com relacionamento um para muitos e fazer um novo Migration.

- **Id_04:**
  - Modelar as entidades com relacionamento muitos para muitos e fazer um novo Migration.

- **Id_05:**
  - Fazer um projeto do tipo Console, colocando o projeto anterior como dependência. Fazer CRUDs de cada entidade para testar as implementações anteriores.

#### Diagrama de Classes:

[Inserir aqui a imagem do Diagrama de Classes]

## Estrutura do Repositório

O repositório está organizado da seguinte forma:

1. Cada tarefa realizada deve ter um Branch com a assinatura: `DOTNET-P005/idtarefa-descricao_breve_da_tarefa`.
2. O desenvolvedor responsável pela tarefa irá fazer todos os commits referentes (e exclusivamente) a essa tarefa nesse Branch.
3. Após finalizar a implementação, o desenvolvedor irá fazer um novo Merge de `EntityFramework` (Origin) em seu Branch (Target) e realizar testes a fim de garantir que tudo ainda esteja funcionando.
4. Em seguida, o desenvolvedor deve criar um Pull Request para o Branch `EntityFramework`, que deverá ser aprovado por alguém da equipe.

**Trilha Básica .NET!**
