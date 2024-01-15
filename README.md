# Trilha .NET

![.NET_logo](https://upload.wikimedia.org/wikipedia/commons/thumb/7/7d/Microsoft_.NET_logo.svg/100px-Microsoft_.NET_logo.svg.png)

## Repositório da Trilha .NET

Este repositório é dedicado à trilha básica da Residência de Software, abrigando as atividades propostas realizadas pelos seguintes integrantes do grupo:

1. Alan Carlos - Repositório no GitHub [AlanSantos01](https://github.com/AlanSantos01)
2. Marcelo Cruz - Repositório no GitHub [Marckcruz](https://github.com/Marckcruz)
3. Daniel Coutinho - Repositório no GitHub [danielcoutinhoneto](https://github.com/danielcoutinhoneto)
4. Franklin - Repositório no GitHub [FranklinPereira2309](https://github.com/FranklinPereira2309)
5. Breno Rios - Repositório no GitHub [Repositório no GitHub](#)
6. Ezequiel Lobo - Repositório no GitHub [EzekLobo](https://github.com/EzekLobo)

### Objetivo

O principal objetivo desta trilha é proporcionar aos participantes uma introdução abrangente ao desenvolvimento com a plataforma .NET, fornecendo uma base sólida para futuros aprendizados e projetos.

Nesta branch, o foco é a arquitetura limpa (Clean Architecture).

A arquitetura limpa (Clean Architecture) é um conceito proposto por Robert C. Martin, também conhecido como Uncle Bob, que busca promover a separação de preocupações e a independência de frameworks em projetos de software. A ideia é criar uma arquitetura que seja fácil de entender, manter e evoluir ao longo do tempo.

A Clean Architecture é baseada em princípios como a inversão de dependência e a separação de conceitos em camadas. Essas camadas geralmente incluem:

- **Entidades:** Representam o núcleo do negócio e contêm as regras de negócio.
- **Casos de uso (Use Cases ou Interactors):** Implementam as regras de negócio específicas da aplicação. Eles orquestram a interação entre entidades e objetos de interface do usuário.
- **Interfaces de Interface do Usuário (UI):** Incluem componentes como interfaces gráficas, controladores de API, etc. Essas interfaces são responsáveis pela interação com o usuário.
- **Interfaces de Serviço (Frameworks e Drivers):** Incluem frameworks e drivers externos, como bibliotecas de persistência, frameworks web, etc. Essa camada é onde ocorre a interação com tecnologias externas.
- **Entidades externas (Interfaces externas ou Gateways):** Permitem a comunicação com elementos externos, como bancos de dados, APIs, dispositivos de hardware, etc.

A principal ideia é que as camadas mais internas não devem depender das camadas mais externas, criando assim uma arquitetura que seja independente de detalhes de implementação e fácil de testar. A inversão de dependência é fundamental nesse contexto, permitindo que as camadas mais internas não dependam diretamente das camadas mais externas, mas sim de abstrações.

Essa abordagem busca garantir que as mudanças na interface do usuário, em frameworks externos ou em detalhes de implementação não afetem as regras de negócio centrais da aplicação. Isso torna o código mais modular, flexível e passível de manutenção ao longo do tempo.

### Tarefa

Esta tarefa baseia-se no projeto básico de arquitetura limpa proposto pelo Prof. José Carlos Macoratti. Siga o passo-a-passo proposto por ele na playlist [Clean Architecture](https://www.youtube.com/watch?v=luyGoZa9is4&list=PLUg4628weKYzPQ9Odqe7jqSTNJbin0j9W&index=1&ab_channel=JoseCarlosMacoratti) com 5 vídeos inseridos no Moodle. O link para o repositório disponibilizado pelo professor Macoratti é [CleanArchitecture_api](https://github.com/macoratti/CleanArchitecture_api).

**Tarefas:**

- **Id_01:**
  - Criar um arquivo markdown `Readme.md` descrevendo essa prática.
  
- **Id_02.seu_nome:**
  - Seguir as orientações no primeiro vídeo: .NET – Usando a Clean Architecture I;
  
- **Id_03.seu_nome:**
  - Seguir as orientações no segundo vídeo: .NET – Usando a Clean Architecture II;
  
- **Id_04.seu_nome:**
  - Seguir as orientações no terceiro vídeo: .NET – Usando a Clean Architecture III;
  
- **Id_05.seu_nome:**
  - Seguir as orientações no quarto vídeo: .NET – Usando a Clean Architecture IV;
  
- **Id_06.seu_nome:**
  - Seguir as orientações no quinto vídeo: .NET – Usando a Clean Architecture V;

### Estrutura do Repositório

O repositório está organizado da seguinte forma:

1. Para cada tarefa a ser realizada, criem um Branch com a seguinte assinatura: `DOTNET-P003/idtarefa-descricao_breve_da_tarefa`.
2. O desenvolvedor responsável pela tarefa irá fazer todos os commits referentes (e exclusivamente) a essa tarefa nesse Branch.
3. Após finalizar o desenvolvimento, o desenvolvedor irá fazer um novo Merge de `CleanArchitecture` (Origin) em seu Branch (Target) e realizar testes a fim de garantir que tudo ainda esteja funcionando.
4. Em seguida, o desenvolvedor deve criar um Pull Request para o Branch `CleanArchitecture`, que deverá ser aprovado por alguém da equipe.

**Trilha Básica .NET!**
