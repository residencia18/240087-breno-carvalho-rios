export interface AtendimentoViewModel {
    id: string,
    // Dados Pessoa
    nomeCliente: string,
    emailCliente: string,
    cpfCliente: string,
    // Dados Pet
    nomePet: string,
    racaPet: string,
    portePet: string,
    sexoPet: string,
    dataNascimentoPet: string,
    // Dados Atendimento
    dataHora: string,
    procedimento: string,
    nomeProfissional: string,
    status: string
}
