## Classe Pessoa

* Em ObterDataDeNascimento(): Digite a data de nascimento do paciente --> Digite a data de nascimento

## Classe Cliente

* Criação do método ToString()

## Classe Advogado

* Criação do método ToString()

## Classe ListaCliente

* Corrigidas várias ocasiões onde era exibido "clientes" no lugar de "cliente"
	
* Condição corrigida em editar cliente: while (Cliente.estadoCivil(estadoCivil)) --> while (!Cliente.estadoCivil(estadoCivil))
	
* Uso do ToString() de cliente em Listar e ExibiDados

## Classe ListaAdvogado

* Uso do ToString() de cliente em Listar e ExibiDados

* Descomentado cadastro de advogados
	

## Classe Relatorios

### Menu:

* [2] - CLIENTE COM IDADE ENTRE DOIS VALORES --> [2] - CLIENTES COM IDADE ENTRE DOIS VALORES
* [3] - CLIENTES COM ESTADO CIVIL INFORMADO PELO CLIENTE --> [3] - CLIENTES COM ESTADO CIVIL INFORMADO PELO USUÁRIO

### Relatórios:

* Corrigidas várias ocasiões onde era exibido "clientes" no lugar de "cliente"

* Corrigidas várias ocasiões onde era exibido "advogados" no lugar de "advogado"

* Renomeado: RelatorioEstadoCivilInformadoPeloCliente --> RelatorioEstadoCivilInformadoPeloUsuario

* Renomeado: paciente --> cliente em RelatorioClientesCujaProfissaoContenhaTexto()

* Adicionadas chamadas para os métodos ToString() de cliente e advogado

* Alterado RelatorioAdvogadosEClientesAniversariantesDoMes() para ler um mês e não pegar o mês atual
