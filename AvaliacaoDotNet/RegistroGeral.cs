using System.Security.Cryptography;

namespace AvaliacaoDotNet;

public static class RegistroGeral
{
    public static List<Advogado> Advogados = new();
    public static List<Cliente> Clientes = new();
    public static List<CasoJuridico> Casos = new();
    public static List<RelacaoCasoAdvogado> RelacoesCasoAdvogado = new();

    public static List<PlanoConsultoria> Planos = new();

    public static void NovoAdvogado()
    {
        App.LimparTela();

        Console.WriteLine("\n\tDigite o nome do Advogado:");
        string nome = App.LerString();

        Console.WriteLine("\n\tDigite a data de nascimento (formato: dd/mm/aaaa):");
        DateTime dtNasc = App.LerData();

        Console.WriteLine("\n\tDigite o CPF:");
        string cpf = App.LerString();

        Console.WriteLine("\n\tDigite o CNA:");
        string cna = App.LerString();

        Console.WriteLine("\n\tDigite a especialidade:");
        string especialidade = App.LerString();


        if (!Pessoa.IsValidCPF(cpf))
        {
            throw new ArgumentException("\n\tOps, CPF inválido!...");
        }

        if (HasAdvogado(cpf, cna))
        {
            App.Cx_Msg("\n\tAdvogado já cadastrado!");
            return;
        }

        Advogado novo = new(nome, dtNasc, cpf, cna, especialidade);
        Advogados.Add(novo);
        App.Cx_Msg("\n\tAdvogado adicionado com sucesso!");
    }

    public static void ExibirAdvogados()
    {
        App.LimparTela();
        Console.Write("\n\t========= Lista de Advogados =========\n");
        foreach (Advogado advogado in Advogados)
        {
            Console.WriteLine(advogado.ToString());
            Console.WriteLine("\t=====================================");
        }
        App.Pause();
    }

    public static void BuscarAdvogado()
    {
        App.LimparTela();
        Console.WriteLine("\n\tDigite o cna do advogado:");
        string cna = App.LerString();

        Advogado? encontrado = Advogados.FirstOrDefault(a => a.Cna == cna);
        if (encontrado == default)
        {
            App.Cx_Msg("\n\tO CPF informado não corresponde a nenhum advogado cadastrado!");
            return;
        }

        int opcao;
        do
        {
            opcao = DispBuscarAdvogado(encontrado);
            switch (opcao)
            {
                case 1:
                    AlterarNomeAdvogado(encontrado);
                    break;
                case 2:
                    AlterarDataAdvogado(encontrado);
                    break;
                case 3:
                    AlterarEspecialidade(encontrado);
                    break;
                case 0:
                    break;
                default:
                    App.Cx_Msg("\n\tOpção Inválida!");
                    break;
            }
        } while (opcao != 0);
    }

    private static int DispBuscarAdvogado(Advogado advogado)
    {

        int opcao = -1;
        do
        {
            App.LimparTela();
            Console.WriteLine("\t====== Advogado Encontrado ======");
            Console.WriteLine(advogado.ToString());
            Console.WriteLine("");
            Console.WriteLine("\t======== TECH ADVOCACIA ========");
            Console.WriteLine("\t[1] - Alterar Nome");
            Console.WriteLine("\t[2] - Alterar Data de Nascimento");
            Console.WriteLine("\t[3] - Alterar Especialidade");
            Console.WriteLine("\t[0] - Retornar ao menu anterior!");
            Console.Write("\t-> ");
            string userInput = Console.ReadLine()!;

            if (string.IsNullOrEmpty(userInput) || !Int32.TryParse(userInput, out opcao))
            {
                Console.WriteLine("\n\tEntrada inválida. Por favor, insira um número válido.");
                App.Pause();
            }
        } while (opcao > 3 || opcao < 0);
        return opcao;
    }

    private static void AlterarNomeAdvogado(Advogado advogado)
    {
        App.LimparTela();
        Console.WriteLine("\n\tDigite o novo nome do advogado:");
        string nome = App.LerString();
        Advogados.Remove(advogado);
        advogado.Nome = nome;
        Advogados.Add(advogado);
        App.Cx_Msg("\n\tNome Alterado com Sucesso!");
    }

    private static void AlterarDataAdvogado(Advogado advogado)
    {
        App.LimparTela();
        Console.WriteLine("\n\tDigite a nova Data de Nascimento (dd/mm/yyyy):");
        DateTime data = App.LerData();
        Advogados.Remove(advogado);
        advogado.DataNascimento = data;
        Advogados.Add(advogado);
        App.Cx_Msg("\n\tData de Nascimento Alterado com Sucesso!");
    }

    private static void AlterarEspecialidade(Advogado advogado)
    {
        App.LimparTela();
        Console.WriteLine("\n\tDigite a nova especialidade do advogado:");
        string especialidade = App.LerString();
        Advogados.Remove(advogado);
        advogado.Especialidade = especialidade;
        Advogados.Add(advogado);
        App.Cx_Msg("\n\tEspecialidade Alterada com Sucesso!");
    }

    public static bool HasAdvogado(string cpf, string cna)
    {
        return Advogados.Any(x => x.Cpf == cpf || x.Cna == cna);
    }

    public static void NovoCliente()
    {
        App.LimparTela();

        Console.WriteLine("\n\tDigite o nome do cliente:");
        string nome = App.LerString();

        Console.WriteLine("\n\tDigite a data de nascimento (formato: dd/mm/aaaa):");
        DateTime dtNasc = App.LerData();

        Console.WriteLine("\n\tDigite o CPF do cliente:");
        string cpf = App.LerString();

        Console.WriteLine("\n\tDigite o estado civil:");
        string estadoCivil = App.LerString();

        Console.WriteLine("\n\tDigite a profissão:");
        string profissao = App.LerString();


        if (!Pessoa.IsValidCPF(cpf))
        {
            throw new ArgumentException("\n\tOps, CPF inválido!...");
        }

        if (HasCliente(cpf))
        {
            App.Cx_Msg("\n\tCliente já cadastrado!");
            return;
        }

        Cliente novo = new(nome, cpf, dtNasc, estadoCivil, profissao);
        Clientes.Add(novo);
        App.Cx_Msg("\n\tCliente adicionado com sucesso!");
    }

    public static void ExibirClientes()
    {
        App.LimparTela();
        Console.Write("\n\t========= Lista de Clientes =========");
        foreach (Cliente cliente in Clientes)
        {
            Console.WriteLine(cliente.ToString());
            Console.WriteLine("\t=====================================");
        }
        App.Pause();
    }

    public static void BuscarCliente()
    {
        App.LimparTela();
        Console.WriteLine("\n\tDigite o CPF do cliente:");
        string cpf = App.LerString();

        Cliente? encontrado = Clientes.FirstOrDefault(c => c.Cpf == cpf);
        if (encontrado == default)
        {
            App.Cx_Msg("\n\tO CPF informado não corresponde a nenhum cliente cadastrado!");
            return;
        }

        int opcao;
        do
        {
            opcao = DispBuscarCliente(encontrado);
            switch (opcao)
            {
                case 1:
                    AlterarNomeCliente(encontrado);
                    break;
                case 2:
                    AlterarDataCliente(encontrado);
                    break;
                case 3:
                    AlterarEstadoCivil(encontrado);
                    break;
                case 4:
                    AlterarProfissao(encontrado);
                    break;
                case 5:
                    NovoPagamento(encontrado);
                    break;
                case 6:
                    encontrado.ExibirPagamentos();
                    break;
                case 0:
                    break;
                default:
                    App.Cx_Msg("Opção Inválida!");
                    break;
            }
        } while (opcao != 0);
    }

    private static int DispBuscarCliente(Cliente cliente)
    {

        int opcao = -1;
        do
        {
            App.LimparTela();
            Console.WriteLine("\t====== Cliente Encontrado ======");
            Console.WriteLine(cliente.ToString());
            Console.WriteLine("");
            Console.WriteLine("\t======== TECH ADVOCACIA ========");
            Console.WriteLine("\t[1] - Alterar Nome");
            Console.WriteLine("\t[2] - Alterar Data de Nascimento");
            Console.WriteLine("\t[3] - Novo Estado Civil");
            Console.WriteLine("\t[4] - Alterar Profissão");
            Console.WriteLine("\t[5] - Novo Pagamento");
            Console.WriteLine("\t[6] - Exibir Pagamentos");
            Console.WriteLine("\t[0] - Retornar ao menu anterior!");
            Console.Write("\t-> ");
            string userInput = Console.ReadLine()!;

            if (string.IsNullOrEmpty(userInput) || !Int32.TryParse(userInput, out opcao))
            {
                Console.WriteLine("\n\tEntrada inválida. Por favor, insira um número válido.");
                App.Pause();
            }
        } while (opcao > 6 || opcao < 0);
        return opcao;
    }

    private static void AlterarNomeCliente(Cliente cliente)
    {
        App.LimparTela();
        Console.WriteLine("\n\tDigite o novo nome do cliente:");
        string nome = App.LerString();
        Clientes.Remove(cliente);
        cliente.Nome = nome;
        Clientes.Add(cliente);
        App.Cx_Msg("\n\tNome Alterado com Sucesso!");
    }

    private static void AlterarDataCliente(Cliente cliente)
    {
        App.LimparTela();
        Console.WriteLine("\n\tDigite a nova Data de Nascimento (dd/mm/yyyy):");
        DateTime data = App.LerData();
        Clientes.Remove(cliente);
        cliente.DataNascimento = data;
        Clientes.Add(cliente);
        App.Cx_Msg("\n\tData de Nascimento Alterado com Sucesso!");
    }

    private static void AlterarEstadoCivil(Cliente cliente)
    {
        App.LimparTela();
        Console.WriteLine("\n\tDigite o novo estado civil do cliente:");
        string estado = App.LerString();
        Clientes.Remove(cliente);
        cliente.EstadoCivil = estado;
        Clientes.Add(cliente);
        App.Cx_Msg("\n\tEstado Civil Alterado com Sucesso!");
    }

    private static void AlterarProfissao(Cliente cliente)
    {
        App.LimparTela();
        Console.WriteLine("\n\tDigite a nova profissão do cliente:");
        string profissao = App.LerString();
        Clientes.Remove(cliente);
        cliente.Profissao = profissao;
        Clientes.Add(cliente);
        App.Cx_Msg("\n\tProfissão Alterada com Sucesso!");
    }

    public static bool HasCliente(string cpf)
    {
        return Clientes.Any(paciente => paciente.Cpf == cpf);
    }

    public static void NovoCaso()
    {
        App.LimparTela();

        Console.Write("\n\tDigite a data de abertura do caso (formato: dd/mm/yyyy): ");
        DateTime data = App.LerData();

        App.LimparTela();
        Console.Write("\n\tDigite o CPF do cliente do caso: ");
        string cpf = App.LerString();

        while (!HasCliente(cpf))
        {
            Console.WriteLine("\n\tCliente não encontrado!");
            Console.Write("\n\tDeseja tentar novamente? [S] / [N]: ");
            cpf = App.LerString();
            if (cpf.ToUpper() == "N")
                return;
            App.LimparTela();
            Console.Write("\n\tDigite o CPF do cliente do caso: ");
            cpf = App.LerString();
        }

        Cliente? cliente = Clientes.FirstOrDefault(c => c.Cpf == cpf);

        if (cliente == default)
            return;

        List<Advogado>? advogadosNoCaso = ColetarAdvogados();

        if (advogadosNoCaso == default)
            return;

        App.LimparTela();
        Console.WriteLine("\n\tAnexar pelo menos um documento ao processo!");
        Documento novo = ColetarDocumento();
        List<Documento> documentosDoCaso = new List<Documento> { novo };

        while (true)
        {
            Console.Write("\n\tDeseja adicionar mais documentos ao caso? [S] / [N]: ");
            string resposta = App.LerString().ToUpper();

            if (resposta == "N")
                break;
            novo = ColetarDocumento();
            documentosDoCaso.Add(novo);
        }

        List<(float, string)> custosDoCaso = ColetarCustos();

        Console.Write("\n\tQual a probabilidade de sucesso? (0.00 a 100.00): ");
        float probabilidade;
        while (!float.TryParse(App.LerString(), out probabilidade) || probabilidade < 0 || probabilidade > 100)
        {
            Console.WriteLine("\n\tValor inválido, tente novamente");
        }


        CasoJuridico novoCaso = new(data, cliente, advogadosNoCaso, probabilidade);
        custosDoCaso.ForEach(c => novoCaso.AdicionarCusto(c.Item1, c.Item2));
        documentosDoCaso.ForEach(novoCaso.AddDocumento);

        foreach (Advogado advogado in advogadosNoCaso)
        {
            RelacaoCasoAdvogado relacao = new(novoCaso, advogado);
        }

        Casos.Add(novoCaso);
        Console.WriteLine("\n\tCaso adicionado com sucesso!");
    }

    public static void BuscarCaso()
    {
        App.LimparTela();
        Console.Write("\n\tDigite o CPF do cliente do caso: ");
        string cpf = App.LerString();

        CasoJuridico? encontrado = Casos.FirstOrDefault(c => c.Cliente.Cpf == cpf);
        if (encontrado == default)
        {
            App.Cx_Msg("\n\tO CPF informado não corresponde a nenhum cliente com caso cadastrado!");
            return;
        }

        int opcao;

        if (encontrado.Status != "Em aberto")
        {
            do
            {
                opcao = DispBuscaCasoEncerrado(encontrado);
            } while (opcao != 0);
        }

        do
        {
            opcao = DispBuscaCaso(encontrado);
            switch (opcao)
            {
                case 1:
                    NovoSucesso(encontrado);
                    break;
                case 2:
                    VerDocumentacao(encontrado);
                    break;
                case 3:
                    VerCustos(encontrado);
                    break;
                case 4:
                    VerAdvogados(encontrado);
                    break;
                case 5:
                    AlterarStatus(encontrado);
                    break;
                case 0:
                    break;
                default:
                    App.Cx_Msg("\n\tSelecione uma opção válida");
                    break;
            }

        } while (opcao != 0);
    }

    private static int DispBuscaCaso(CasoJuridico caso)
    {
        int opcao = -1;
        do
        {
            App.LimparTela();
            Console.WriteLine("\t====== Caso Encontrado ======");
            Console.WriteLine(caso.ToString());
            Console.WriteLine("");
            Console.WriteLine("\t======== TECH ADVOCACIA ========");
            Console.WriteLine("\t[1] - Nova Probabilidade de Sucesso");
            Console.WriteLine("\t[2] - Documentação");
            Console.WriteLine("\t[3] - Custos");
            Console.WriteLine("\t[4] - Advogados no caso");
            Console.WriteLine("\t[5] - Alterar status do caso");
            Console.WriteLine("\t[0] - Retornar ao menu anterior!");
            Console.Write("\t-> ");
            string userInput = Console.ReadLine()!;

            if (string.IsNullOrEmpty(userInput) || !Int32.TryParse(userInput, out opcao))
            {
                Console.WriteLine("\n\tEntrada inválida. Por favor, insira um número válido.");
                App.Pause();
            }
        } while (opcao > 5 || opcao < 0);
        return opcao;
    }

    private static int DispBuscaCasoEncerrado(CasoJuridico caso)
    {
        int opcao = -1;
        do
        {
            App.LimparTela();
            Console.WriteLine("\t====== Caso Encontrado ======");
            Console.WriteLine(caso.ToString());
            Console.WriteLine("\n\t======== TECH ADVOCACIA ========");
            Console.WriteLine("\t[0] - Retornar ao menu anterior!");
            Console.Write("\t-> ");
            string userInput = Console.ReadLine()!;

            if (string.IsNullOrEmpty(userInput) || !Int32.TryParse(userInput, out opcao))
            {
                Console.WriteLine("\n\tEntrada inválida. Por favor, insira um número válido.");
                App.Pause();
            }
        } while (opcao != 0);
        return opcao;
    }

    private static void NovoSucesso(CasoJuridico caso)
    {
        App.LimparTela();
        Console.WriteLine("\n\tInforme a nova probabilidade de sucesso do caso:");
        string input = App.LerString();
        float probabilidade;
        while (!float.TryParse(input, out probabilidade) || probabilidade < 0 || probabilidade > 100)
            Console.WriteLine("\n\tValor inválido, tente novamente");
        caso.ProbabilidadeSucesso = probabilidade;
        App.Cx_Msg("\n\tProbabilidade de Sucesso Alterada!");
    }

    private static void VerDocumentacao(CasoJuridico caso)
    {
        while (true)
        {
            App.LimparTela();
            Console.WriteLine("\n\t==== Documentos do Caso Jurídico ====");

            for (int i = 0; i < caso.Documentos.Count; i++)
                Console.WriteLine($"at{i + 1}. Código: {caso.Documentos[i].Codigo}\n\t Tipo: {caso.Documentos[i].Tipo}\n\t Descrição: {caso.Documentos[i].Descricao}");

            Console.WriteLine("\n\tDeseja inserir ou remover um documento?");
            Console.WriteLine("\t1. Inserir Documento");
            Console.WriteLine("\t2. Remover Documento");
            Console.WriteLine("\t3. Retornar ao menu anterior");

            Console.Write("\t-> ");
            string escolha = App.LerString();

            switch (escolha)
            {
                case "1":
                    try
                    {
                        caso.AddDocumento(ColetarDocumento());
                    }
                    catch (InvalidOperationException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"\tOcorreu um erro inesperado: {e.Message}");
                    }
                    break;
                case "2":
                    try
                    {
                        caso.RemoveDocumento(App.LerNumeroInteiro("\tInforme o código do documento:"));
                    }
                    catch (InvalidOperationException e)
                    {
                        App.Cx_Msg(e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"\tOcorreu um erro inesperado: {e.Message}");
                    }
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("\tOpção inválida. Tente novamente.");
                    break;
            }
        }
    }

    private static void VerCustos(CasoJuridico caso)
    {
        while (true)
        {
            App.LimparTela();
            Console.WriteLine("\n\t==== Custos do Caso Jurídico ====");

            for (int i = 0; i < caso.Custos.Count; i++)
                Console.WriteLine($"\t{i + 1}. Valor: {caso.Custos[i].Item1:C2}\n\tDescrição: {caso.Custos[i].Item2}");
            Console.WriteLine("\t=================================");
            Console.WriteLine("\n\tDeseja inserir ou remover um custo?");
            Console.WriteLine("\t1. Inserir Custo");
            Console.WriteLine("\t2. Remover Custo");
            Console.WriteLine("\t3. Sair");
            Console.Write("\tEscolha a opção: ");
            string escolha = App.LerString();

            switch (escolha)
            {
                case "1":
                    InserirCusto(caso);
                    break;
                case "2":
                    RemoverCusto(caso);
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("\n\tOpção inválida. Tente novamente.");
                    break;
            }
        }
    }

    private static void VerAdvogados(CasoJuridico caso)
    {
        List<Advogado> advogadosNoCaso = new();
        foreach (var relacao in RelacaoCasoAdvogado.listaCasoAdvogados)
        {
            if (relacao.Caso.Equals(caso))
                advogadosNoCaso.Add(relacao.Advogado);
        }
        while (true)
        {
            App.LimparTela();
            Console.WriteLine("\n\t==== Advogados do Caso Jurídico ====");

            foreach (var advogado in advogadosNoCaso)
            {
                Console.WriteLine($"\tNome: {advogado.Nome}\n\tCNA: {advogado.Cna}\n\tEspecialidade: {advogado.Especialidade}");
                Console.WriteLine("\t====================================");
            }

            Console.WriteLine("\n\tDeseja inserir ou remover um Advogado?");
            Console.WriteLine("\t1. Inserir Advogado");
            Console.WriteLine("\t2. Remover Advogado");
            Console.WriteLine("\t3. Retornar ao menu anterior");

            Console.Write("\t-> ");
            string escolha = App.LerString();

            switch (escolha)
            {
                case "1":
                    List<Advogado>? novosAdvogados = ColetarAdvogados();
                    if (novosAdvogados == default)
                        continue;
                    foreach (Advogado advogado in novosAdvogados)
                    {
                        RelacaoCasoAdvogado relacao = new(caso, advogado);
                        RelacaoCasoAdvogado.listaCasoAdvogados.Add(relacao);
                    }
                    break;
                case "2":
                    if (advogadosNoCaso.Count == 1)
                    {
                        App.Cx_Msg("\n\tPelo menos um advogado precisa ser designado ao caso");
                        continue;
                    }
                    RemoverAssociacaoAdvogadoCaso(caso);
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("\n\tOpção inválida. Tente novamente.");
                    break;
            }
        }
    }

    public static void RemoverAssociacaoAdvogadoCaso(CasoJuridico caso)
    {
        Console.Write("\n\tInforme o cna do advogado que deseja remover:");
        string cna = App.LerString();

        RelacaoCasoAdvogado? associacaoParaRemover = RelacaoCasoAdvogado.listaCasoAdvogados.FirstOrDefault(a =>
            a.Advogado.Cna.Equals(cna) && a.Caso.Equals(caso));

        if (associacaoParaRemover != null)
        {
            RelacaoCasoAdvogado.listaCasoAdvogados.Remove(associacaoParaRemover);
            Console.WriteLine("\n\tAdvogado removido com sucesso.");
        }
        else
            Console.WriteLine("\n\tAssociação não encontrada.");

        Console.ReadLine();
    }

    public static void AlterarStatus(CasoJuridico caso)
    {
        while (true)
        {
            App.LimparTela();
            Console.WriteLine("\n\t==== Status do Caso Jurídico ====");
            Console.WriteLine($"\n\tData de abertura: {caso.DataInicio.ToShortDateString()}");
            Console.WriteLine($"\n\tStatus atual: {caso.Status}");
            Console.WriteLine("\t=================================");

            Console.WriteLine("\n\tDeseja alterar o status do caso?");
            Console.WriteLine("\t1. Concluído");
            Console.WriteLine("\t2. Arquivado");
            Console.WriteLine("\t0. Retornar ao menu anterior");
            Console.Write("\t-> ");
            string escolha = App.LerString();
            DateTime data;

            switch (escolha)
            {
                case "1":
                    do
                    {
                        Console.Write("\n\tInforme a data de encerramento: ");
                        data = App.LerData();
                        if (caso.DataInicio < data)
                        {
                            break;
                        }
                        Console.WriteLine("\n\tA data de encerramento deve ser posterior a de abertura!");
                    } while (true);
                    caso.DataEncerramento = data;
                    caso.Status = "Concluído";
                    Console.WriteLine("\n\tStatus alterado para Concluído.");
                    break;
                case "2":
                    do
                    {
                        Console.Write("\n\tInforme a data de encerramento: ");
                        data = App.LerData();
                        if (caso.DataInicio > data)
                            break;
                        Console.WriteLine("\n\tA data de encerramento deve ser posterior a de abertura!");
                    } while (true);
                    caso.DataEncerramento = data;
                    caso.Status = "Arquivado";
                    Console.WriteLine("\n\tStatus alterado para Arquivado.");
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("\n\tOpção inválida. Tente novamente.");
                    break;
            }

            Console.ReadLine(); // Apenas para aguardar uma tecla antes de voltar ao menu.
        }
    }

    private static void InserirCusto(CasoJuridico caso)
    {
        App.LimparTela();
        Console.Write("\n\tInforme o valor do custo: ");
        if (float.TryParse(Console.ReadLine(), out float valor))
        {
            Console.Write("\n\tInforme a descrição do custo: ");
            string descricao = App.LerString();

            try
            {
                caso.AdicionarCusto(valor, descricao);
            }
            catch (InvalidOperationException e)
            {
                App.Cx_Msg(e.Message);
            }
        }
        else
            Console.WriteLine("\n\tValor de custo inválido.");

        App.Pause();
    }

    private static void RemoverCusto(CasoJuridico caso)
    {
        App.LimparTela();
        Console.Write("\n\tInforme o valor do custo: ");
        if (float.TryParse(Console.ReadLine(), out float valor))
        {
            Console.Write("\n\tInforme a descrição do custo: ");
            string descricao = App.LerString();

            try
            {
                caso.RemoverCusto(valor, descricao);
            }
            catch (InvalidOperationException e)
            {
                App.Cx_Msg(e.Message);
            }
        }
        else
            Console.WriteLine("\n\tValor de custo inválido.");

        App.Pause();
    }

    private static List<Advogado>? ColetarAdvogados()
    {
        App.LimparTela();
        Console.Write("\n\tDigite o cna do advogado resposável pelo caso: ");
        string cna = App.LerString();
        Advogado? advogado = Advogados.FirstOrDefault(a => a.Cna == cna);
        List<Advogado> advogadosNoCaso = new();

        while (advogado == default)
        {
            Console.WriteLine("\n\tAdvogado não encontrado!");
            Console.Write("\n\tDeseja tentar novamente? [S] / [N]: ");
            cna = App.LerString();
            if (cna.ToUpper() == "N")
                return default;
            App.LimparTela();
            Console.Write("\n\tDigite o cna do advogado resposável pelo caso: ");
            cna = App.LerString();
            advogado = Advogados.FirstOrDefault(a => a.Cna == cna);
        }

        advogadosNoCaso.Add(advogado);

        while (true)
        {
            App.LimparTela();
            Console.Write("\n\tDeseja adicionar mais advogados ao caso? [S] / [N]: ");
            string resposta = App.LerString().ToUpper();

            if (resposta == "N")
                break;

            Console.Write("\n\tDigite o cna do próximo advogado: ");
            cna = App.LerString();
            advogado = Advogados.FirstOrDefault(a => a.Cna == cna);

            if (advogado == default)
            {
                App.Cx_Msg("\n\tAdvogado não encontrado!");
                continue;
            }

            advogadosNoCaso.Add(advogado);
        }
        return advogadosNoCaso;
    }

    private static Documento ColetarDocumento()
    {
        Console.Write("\n\tInforme o tipo do documento do caso: ");
        string tipo = App.LerString();

        int codigo = App.LerNumeroInteiro("\n\tInforme o código do documento: ");

        Console.Write("\n\tInforme a data de modificação do documento: ");
        DateTime data = App.LerData();

        Console.Write("\n\tInforme a descrição do documento: ");
        string descricao = App.LerString();

        Documento documento = new(data, codigo, tipo, descricao);
        return documento;
    }

    private static List<(float, string)> ColetarCustos()
    {
        List<(float, string)> custos = new List<(float, string)>();

        while (true)
        {
            Console.Write("\n\tInforme o valor do custo: ");
            float valor;
            while (!float.TryParse(App.LerString(), out valor))
                Console.WriteLine("\n\tValor inválido. Tente novamente.");

            Console.Write("\n\tInforme a descrição do custo: ");
            string descricao = App.LerString();

            custos.Add((valor, descricao));

            Console.Write("\n\tDeseja adicionar mais custos? [S] / [N]: ");
            string resposta = App.LerString().ToUpper();
            if (resposta != "S")
                break;
        }
        return custos;
    }

    public static void NovoPlano()
    {

        //Criando novo plano com os atributos titulo e valor
        App.LimparTela();
        Console.WriteLine("\n\tDigite o titulo do plano:");
        string titulo = App.LerString();

        double valor = App.LerDouble("\n\tDigite o valor do plano:");

        PlanoConsultoria novo = new(titulo, valor);

        string resposta;
        do
        {

            Console.WriteLine("\n\tDeseja cadastrar um novo beneficio? [S] / [N]: ");
            resposta = App.LerString().ToUpper();

            if (resposta == "N")
                break;

            Console.WriteLine("\n\tDigite o beneficio:");
            string nome = App.LerString();

            novo.NovoBeneficio(nome);

            App.Cx_Msg("\n\tBeneficio adicionado com sucesso!");

        } while (resposta != "N");

        Planos.Add(novo);

        App.Cx_Msg("\n\tPlano adicionado com sucesso!");

    }

    public static void ExibirPlanos()
    {
        App.LimparTela();
        Console.WriteLine("\n\t========= Lista de Planos =========\n");
        foreach (PlanoConsultoria plano in Planos)
        {
            Console.WriteLine(plano.ToString());
            Console.WriteLine("\t=====================================");
        }
        App.Pause();
    }

    public static void RemoverPlano()
    {

        App.LimparTela();
        Console.WriteLine("\n\tDigite o titulo do plano:");
        string titulo = App.LerString();

        PlanoConsultoria? encontrado = Planos.FirstOrDefault(p => p.Titulo == titulo);
        if (encontrado == default)
        {
            App.Cx_Msg("\n\tO titulo informado não corresponde a nenhum plano cadastrado!");
            return;
        }

        Planos.Remove(encontrado);
        App.Cx_Msg("\n\tPlano removido com sucesso!");
    }

    public static void BuscarPlano()
    {

        App.LimparTela();
        Console.WriteLine("\n\tDigite o titulo do plano:");
        string titulo = App.LerString();

        PlanoConsultoria? encontrado = Planos.FirstOrDefault(p => p.Titulo == titulo);
        if (encontrado == default)
        {
            App.Cx_Msg("\n\tO titulo informado não corresponde a nenhum plano cadastrado!");
            return;
        }

        int opcao;
        do
        {
            opcao = DispBuscarPlano(encontrado);
            switch (opcao)
            {
                case 1:
                    AdcionarBeneficio(encontrado);
                    break;
                case 2:
                    RemoverBeneficio(encontrado);
                    break;
                case 0:
                    break;
                default:
                    App.Cx_Msg("\n\tOpção Inválida!");
                    break;
            }
        } while (opcao != 0);
    }

    public static int DispBuscarPlano(PlanoConsultoria plano)
    {
        int opcao = -1;
        do
        {
            App.LimparTela();
            Console.WriteLine("\t====== Plano Encontrado ======");
            Console.WriteLine(plano.ToString());
            Console.WriteLine("");
            Console.WriteLine("\t======== TECH ADVOCACIA ========");
            Console.WriteLine("\t[1] - Inserir Beneficio");
            Console.WriteLine("\t[2] - Remover Beneficio");
            Console.WriteLine("\t[0] - Retornar ao menu anterior!");
            Console.Write("\t-> ");
            string userInput = Console.ReadLine()!;

            if (string.IsNullOrEmpty(userInput) || !Int32.TryParse(userInput, out opcao))
            {
                Console.WriteLine("\n\tEntrada inválida. Por favor, insira um número válido.");
                App.Pause();
            }
        } while (opcao > 2 || opcao < 0);

        return opcao;
    }

    public static void AdcionarBeneficio(PlanoConsultoria plano)
    {
        App.LimparTela();
        Console.WriteLine("\n\tDigite o beneficio:");
        string nome = App.LerString();

        plano.NovoBeneficio(nome);

        App.Cx_Msg("\n\tBeneficio adicionado com sucesso!");
    }

    public static void RemoverBeneficio(PlanoConsultoria plano)
    {
        App.LimparTela();
        Console.WriteLine("\n\tDigite o beneficio:");
        string nome = App.LerString();

        plano.RetirarBeneficio(nome);

        App.Cx_Msg("\n\tBeneficio removido com sucesso!");
    }

    // função para criar novo pagamento obtendo descrição, valor bruto e perguntar ao usuário se houver um desconto
    public static void NovoPagamento(Cliente cliente)
    {

        App.LimparTela();
        Console.WriteLine("\n\tDigite a descrição do pagamento:");
        string descricao = App.LerString();

        double valorBruto = App.LerDouble("\n\tDigite o valor bruto do pagamento:");

        Console.WriteLine("\n\tDeseja aplicar um desconto? [S] / [N]: ");
        string resposta = App.LerString().ToUpper();

        double desconto = 0;

        if (resposta == "S")
            desconto = App.LerDouble("\n\tDigite o valor do desconto:");

        // perguntar se o pagamento é credito, pix ou dinheiro

        int opcao = DispPagamento();

        switch (opcao)
        {
            case 1:
                CartaoCredito novoCredito = new(descricao, valorBruto, desconto);
                cliente.NovoPagamento(novoCredito);
                break;

            case 2:
                PagamentoEmPix novoPix = new(descricao, valorBruto, desconto);
                cliente.NovoPagamento(novoPix);
                break;

            case 3:
                PagamentoEmDinheiro novoDinheiro = new(descricao, valorBruto, desconto);
                cliente.NovoPagamento(novoDinheiro);
                break;
            default:
                Console.WriteLine("\n\tOpção Inválida!");
                break;
        }

        App.Cx_Msg("\n\tPagamento adicionado com sucesso!");
    }

    public static int DispPagamento()
    {

        int opcao = -1;
        do
        {
            App.LimparTela();
            Console.WriteLine("\t====== Forma de Pagamento ======");
            Console.WriteLine("");
            Console.WriteLine("\t======== TECH ADVOCACIA ========");
            Console.WriteLine("\t[1] - Crédito");
            Console.WriteLine("\t[2] - Pix");
            Console.WriteLine("\t[3] - Dinheiro");
            Console.WriteLine("\t[0] - Retornar ao menu anterior!");
            Console.Write("\t-> ");
            string userInput = Console.ReadLine()!;

            if (string.IsNullOrEmpty(userInput) || !Int32.TryParse(userInput, out opcao))
            {
                Console.WriteLine("\n\tEntrada inválida. Por favor, insira um número válido.");
                App.Pause();
            }
        } while (opcao > 3 || opcao < 0);

        return opcao;
    }


}