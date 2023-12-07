namespace AvaliacaoDotNet;

public static class RegistroGeral{
    public static List<Advogado> Advogados = new();
    public static List<Cliente> Clientes = new();
    public static List<CasoJuridico> Casos = new();
    public static List<RelacaoCasoAdvogado> RelacoesCasoAdvogado = new();


    public static void NovoAdvogado(){
        App.LimparTela();

        Console.WriteLine("Digite o nome do Advogado:");
        string nome = App.LerString();

        Console.WriteLine("Digite a data de nascimento (formato: dd/mm/aaaa):");
        DateTime dtNasc = App.LerData();

        Console.WriteLine("Digite o CPF:");
        string cpf = App.LerString();

        Console.WriteLine("Digite o CNA:");
        string cna = App.LerString();

        Console.WriteLine("Digite a especialidade:");
        string especialidade = App.LerString();
        
        
        if (!Pessoa.IsValidCPF(cpf)){
            throw new ArgumentException("\n\tOps, CPF inválido!...");
        }
        
        if(HasAdvogado(cpf, cna)){
            App.Cx_Msg("Advogado já cadastrado!");
            return;
        }

        Advogado novo = new(nome, dtNasc, cpf, cna, especialidade);
        Advogados.Add(novo);
        App.Cx_Msg("Advogado adicionado com sucesso!");
    }

    public static void ExibirAdvogados(){
        App.LimparTela();
        Console.WriteLine("========= Lista de Advogados =========");
        foreach (Advogado advogado in Advogados){
            Console.WriteLine(advogado.ToString());
            Console.WriteLine("=====================================");
        }
        App.Pause();
    }

    public static void BuscarAdvogado(){
        App.LimparTela();
        Console.WriteLine("Digite o cna do advogado:");
        string cna = App.LerString();

        Advogado? encontrado = Advogados.FirstOrDefault(a => a.Cna == cna);
        if(encontrado == default){
            App.Cx_Msg("O CPF informado não corresponde a nenhum advogado cadastrado!");
            return;
        }

        int opcao;
        do{
            opcao = DispBuscarAdvogado(encontrado);
            switch (opcao){
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
                    App.Cx_Msg("Opção Inválida!");
                    break;
            }
        } while (opcao != 0);
    }

    private static int DispBuscarAdvogado(Advogado advogado){
        
        int opcao = -1;
        do{
            App.LimparTela();
            Console.WriteLine("====== Advogado Encontrado ======");
            Console.WriteLine(advogado.ToString());
            Console.WriteLine("");
            Console.WriteLine("\t======== TECH ADVOCACIA ========");
            Console.WriteLine("\t[1] - Alterar Nome");
            Console.WriteLine("\t[2] - Alterar Data de Nascimento");
            Console.WriteLine("\t[3] - Alterar Especialidade");
            Console.WriteLine("\t[0] - Retornar ao menu anterior!");
            Console.Write("\t-> ");
            string userInput = Console.ReadLine()!;

            if (string.IsNullOrEmpty(userInput) || !Int32.TryParse(userInput, out opcao)){
                Console.WriteLine("\n\tEntrada inválida. Por favor, insira um número válido.");
                App.Pause();
            }
        } while (opcao > 3 || opcao < 0);
        return opcao;
    }

    private static void AlterarNomeAdvogado(Advogado advogado){
        App.LimparTela();
        Console.WriteLine("Digite o novo nome do advogado:");
        string nome = App.LerString();
        Advogados.Remove(advogado);
        advogado.Nome = nome;
        Advogados.Add(advogado);
        App.Cx_Msg("Nome Alterado com Sucesso!");
    }
    
    private static void AlterarDataAdvogado(Advogado advogado){
        App.LimparTela();
        Console.WriteLine("Digite a nova Data de Nascimento (dd/mm/yyyy):");
        DateTime data = App.LerData();
        Advogados.Remove(advogado);
        advogado.DataNascimento = data;
        Advogados.Add(advogado);
        App.Cx_Msg("Data de Nascimento Alterado com Sucesso!");
    }

    private static void AlterarEspecialidade(Advogado advogado){
        App.LimparTela();
        Console.WriteLine("Digite a nova especialidade do advogado:");
        string especialidade = App.LerString();
        Advogados.Remove(advogado);
        advogado.Especialidade = especialidade;
        Advogados.Add(advogado);
        App.Cx_Msg("Especialidade Alterada com Sucesso!");
    }

    public static bool HasAdvogado(string cpf, string cna){
        return Advogados.Any(x => x.Cpf == cpf || x.Cna == cna);
    }



    public static void NovoCliente(){
        App.LimparTela();

        Console.WriteLine("Digite o nome do cliente:");
        string nome = App.LerString();

        Console.WriteLine("Digite a data de nascimento (formato: dd/mm/aaaa):");
        DateTime dtNasc = App.LerData();

        Console.WriteLine("Digite o CPF do cliente:");
        string cpf = App.LerString();

        Console.WriteLine("Digite o estado civil:");
        string estadoCivil = App.LerString();

        Console.WriteLine("Digite a profissão:");
        string profissao = App.LerString();
        
        
        if (!Pessoa.IsValidCPF(cpf)){
            throw new ArgumentException("\n\tOps, CPF inválido!...");
        }
        
        if(HasCliente(cpf)){
            App.Cx_Msg("Cliente já cadastrado!");
            return;
        }

        Cliente novo = new(nome, cpf, dtNasc, estadoCivil, profissao);
        Clientes.Add(novo);
        App.Cx_Msg("Cliente adicionado com sucesso!");
    }

    public static void ExibirClientes(){
        App.LimparTela();
        Console.WriteLine("========= Lista de Clientes =========");
        foreach (Cliente cliente in Clientes){
            Console.WriteLine(cliente.ToString());
            Console.WriteLine("=====================================");
        }
        App.Pause();
    }

    public static void BuscarCliente(){
        App.LimparTela();
        Console.WriteLine("Digite o CPF do cliente:");
        string cpf = App.LerString();

        Cliente? encontrado = Clientes.FirstOrDefault(c => c.Cpf == cpf);
        if(encontrado == default){
            App.Cx_Msg("O CPF informado não corresponde a nenhum cliente cadastrado!");
            return;
        }

        int opcao;
        do{
            opcao = DispBuscarCliente(encontrado);
            switch (opcao){
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
                case 0:
                    break;
                default:
                    App.Cx_Msg("Opção Inválida!");
                    break;
            }
        } while (opcao != 0);
    }

    private static int DispBuscarCliente(Cliente cliente){
        
        int opcao = -1;
        do{
            App.LimparTela();
            Console.WriteLine("====== Cliente Encontrado ======");
            Console.WriteLine(cliente.ToString());
            Console.WriteLine("");
            Console.WriteLine("\t======== TECH ADVOCACIA ========");
            Console.WriteLine("\t[1] - Alterar Nome");
            Console.WriteLine("\t[2] - Alterar Data de Nascimento");
            Console.WriteLine("\t[3] - Novo Estado Civil");
            Console.WriteLine("\t[4] - Alterar Profissão");
            Console.WriteLine("\t[0] - Retornar ao menu anterior!");
            Console.Write("\t-> ");
            string userInput = Console.ReadLine()!;

            if (string.IsNullOrEmpty(userInput) || !Int32.TryParse(userInput, out opcao)){
                Console.WriteLine("\n\tEntrada inválida. Por favor, insira um número válido.");
                App.Pause();
            }
        } while (opcao > 4 || opcao < 0);
        return opcao;
    }

    private static void AlterarNomeCliente(Cliente cliente){
        App.LimparTela();
        Console.WriteLine("Digite o novo nome do cliente:");
        string nome = App.LerString();
        Clientes.Remove(cliente);
        cliente.Nome = nome;
        Clientes.Add(cliente);
        App.Cx_Msg("Nome Alterado com Sucesso!");
    }
    
    private static void AlterarDataCliente(Cliente cliente){
        App.LimparTela();
        Console.WriteLine("Digite a nova Data de Nascimento (dd/mm/yyyy):");
        DateTime data = App.LerData();
        Clientes.Remove(cliente);
        cliente.DataNascimento = data;
        Clientes.Add(cliente);
        App.Cx_Msg("Data de Nascimento Alterado com Sucesso!");
    }

    private static void AlterarEstadoCivil(Cliente cliente){
        App.LimparTela();
        Console.WriteLine("Digite o novo estado civil do cliente:");
        string estado = App.LerString();
        Clientes.Remove(cliente);
        cliente.EstadoCivil = estado;
        Clientes.Add(cliente);
        App.Cx_Msg("Estado Civil Alterado com Sucesso!");
    }

    private static void AlterarProfissao(Cliente cliente){
        App.LimparTela();
        Console.WriteLine("Digite a nova profissão do cliente:");
        string profissao = App.LerString();
        Clientes.Remove(cliente);
        cliente.Profissao = profissao;
        Clientes.Add(cliente);
        App.Cx_Msg("Profissão Alterada com Sucesso!");
    }

    public static bool HasCliente(string cpf){
        return Clientes.Any(paciente => paciente.Cpf == cpf);
    }



    public static void NovoCaso(){
        App.LimparTela();

        Console.WriteLine("Digite a data de abertura do caso (formato: dd/mm/yyyy):");
        DateTime data = App.LerData();

        App.LimparTela();
        Console.WriteLine("Digite o CPF do cliente do caso:");
        string cpf = App.LerString();

        while(!HasCliente(cpf)){
            Console.WriteLine("Cliente não encontrado!");
            Console.WriteLine("Deseja tentar novamente? [S] / [N]");
            cpf = App.LerString();
            if(cpf.ToUpper() == "N")
                return;
            App.LimparTela();
            Console.WriteLine("Digite o CPF do cliente do caso:");
            cpf = App.LerString();
        }

        Cliente? cliente = Clientes.FirstOrDefault(c => c.Cpf == cpf);
        
        if (cliente == default)
            return;

        List<Advogado>? advogadosNoCaso = ColetarAdvogados();

        if(advogadosNoCaso == default)
            return;

        App.LimparTela();
        Console.WriteLine("Anexar pelo menos um documento ao processo!");
        Documento novo = ColetarDocumento();
        List<Documento> documentosDoCaso = new List<Documento> {novo};

        while (true){
            Console.WriteLine("Deseja adicionar mais documentos ao caso? [S] / [N]");
            string resposta = App.LerString().ToUpper();

            if (resposta == "N")
                break;
            novo = ColetarDocumento();
            documentosDoCaso.Add(novo);
        }

        List<(float, string)> custosDoCaso = ColetarCustos();

        Console.WriteLine("Qual a probabilidade de sucesso? (0.00 a 100.00)");
        float probabilidade;
        while(!float.TryParse(App.LerString(), out probabilidade) || probabilidade < 0 || probabilidade > 100){
            Console.WriteLine("Valor inválido, tente novamente");
        }


        CasoJuridico novoCaso = new(data, cliente, advogadosNoCaso, probabilidade);
        custosDoCaso.ForEach(c => novoCaso.AdicionarCusto(c.Item1, c.Item2));
        documentosDoCaso.ForEach(novoCaso.AddDocumento);

        foreach (Advogado advogado in advogadosNoCaso){
            RelacaoCasoAdvogado relacao = new(novoCaso, advogado);
        }
    
        Casos.Add(novoCaso);
        Console.WriteLine("Caso adicionado com sucesso!");
    }

    public static void BuscarCaso(){
        App.LimparTela();
        Console.WriteLine("Digite o CPF do cliente do caso:");
        string cpf = App.LerString();

        CasoJuridico? encontrado = Casos.FirstOrDefault(c => c.Cliente.Cpf == cpf);
        if(encontrado == default){
            App.Cx_Msg("O CPF informado não corresponde a nenhum cliente com caso cadastrado!");
            return;
        }
        
        int opcao;

        if(encontrado.Status != "Em aberto"){
            do{
                opcao = DispBuscaCasoEncerrado(encontrado);
            } while (opcao != 0);
        }

        do{
            opcao = DispBuscaCaso(encontrado);
            switch (opcao){
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
                    App.Cx_Msg("Selecione uma opção válida");
                    break;
            }

        } while (opcao != 0);
    }

    private static int DispBuscaCaso(CasoJuridico caso){
        int opcao = -1;
        do{
            App.LimparTela();
            Console.WriteLine("====== Caso Encontrado ======");
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

            if (string.IsNullOrEmpty(userInput) || !Int32.TryParse(userInput, out opcao)){
                Console.WriteLine("\n\tEntrada inválida. Por favor, insira um número válido.");
                App.Pause();
            }
        } while (opcao > 5 || opcao < 0);
        return opcao;
    }

    private static int DispBuscaCasoEncerrado(CasoJuridico caso){
        int opcao = -1;
        do{
            App.LimparTela();
            Console.WriteLine("====== Caso Encontrado ======");
            Console.WriteLine(caso.ToString());
            Console.WriteLine("");
            Console.WriteLine("\t[0] - Retornar ao menu anterior!");
            Console.Write("\t-> ");
            string userInput = Console.ReadLine()!;

            if (string.IsNullOrEmpty(userInput) || !Int32.TryParse(userInput, out opcao)){
                Console.WriteLine("\n\tEntrada inválida. Por favor, insira um número válido.");
                App.Pause();
            }
        } while (opcao != 0);
        return opcao;
    }

    private static void NovoSucesso(CasoJuridico caso){
        App.LimparTela();
        Console.WriteLine("Informe a nova probabilidade de sucesso do caso:");
        string input = App.LerString();
        float probabilidade;
        while(!float.TryParse(input, out probabilidade) || probabilidade < 0 || probabilidade > 100)
            Console.WriteLine("Valor inválido, tente novamente"); 
        caso.ProbabilidadeSucesso = probabilidade;
        App.Cx_Msg("Probabilidade de Sucesso Alterada!");
    }

    private static void VerDocumentacao(CasoJuridico caso){
        while (true){
            App.LimparTela();
            Console.WriteLine("Documentações do Caso Jurídico:");

            for (int i = 0; i < caso.Documentos.Count; i++)
                Console.WriteLine($"{i + 1}. Código: {caso.Documentos[i].Codigo}, Tipo: {caso.Documentos[i].Tipo}, Descrição: {caso.Documentos[i].Descricao}");

            Console.WriteLine("\nDeseja inserir ou remover um documento?");
            Console.WriteLine("1. Inserir Documento");
            Console.WriteLine("2. Remover Documento");
            Console.WriteLine("3. Retornar ao menu anterior");

            Console.Write("-> ");
            string escolha = App.LerString();

            switch (escolha){
                case "1":
                    try {
                        caso.AddDocumento(ColetarDocumento());
                    } catch(InvalidOperationException e) {
                        Console.WriteLine(e.Message);
                    } catch (Exception e) {
                        Console.WriteLine($"Ocorreu um erro inesperado: {e.Message}");                        
                    }
                    break;
                case "2":
                    try{
                        caso.RemoveDocumento(App.LerNumeroInteiro("Informe o código do documento:"));
                    } catch (InvalidOperationException e){
                        App.Cx_Msg(e.Message);
                    } catch (Exception e) {
                        Console.WriteLine($"Ocorreu um erro inesperado: {e.Message}");                        
                    }
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    private static void VerCustos(CasoJuridico caso){
        while (true){
            App.LimparTela();
            Console.WriteLine("Custos do Caso Jurídico:");
            
            for (int i = 0; i < caso.Custos.Count; i++)
                Console.WriteLine($"{i + 1}. Valor: {caso.Custos[i].Item1:C2}, Descrição: {caso.Custos[i].Item2}");

            Console.WriteLine("\nOpções:");
            Console.WriteLine("1. Inserir Custo");
            Console.WriteLine("2. Remover Custo");
            Console.WriteLine("3. Sair");

            Console.Write("Escolha a opção: ");
            string escolha = App.LerString();

            switch (escolha){
                case "1":
                    InserirCusto(caso);
                    break;
                case "2":
                    RemoverCusto(caso);
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    private static void VerAdvogados(CasoJuridico caso){
        List<Advogado> advogadosNoCaso = new();
        foreach (var relacao in RelacaoCasoAdvogado.listaCasoAdvogados){
            if(relacao.Caso.Equals(caso))
                advogadosNoCaso.Add(relacao.Advogado);
        }
        while (true){
            App.LimparTela();
            Console.WriteLine("Advogados do Caso Jurídico:");

            foreach (var advogado in advogadosNoCaso){
                Console.WriteLine($"Nome: {advogado.Nome}, CNA: {advogado.Cna}, Especialidade: {advogado.Especialidade}");
            }

            Console.WriteLine("\nDeseja inserir ou remover um Advogado?");
            Console.WriteLine("1. Inserir Advogado");
            Console.WriteLine("2. Remover Advogado");
            Console.WriteLine("3. Retornar ao menu anterior");

            Console.Write("-> ");
            string escolha = App.LerString();

            switch (escolha){
                case "1":
                    List<Advogado>? novosAdvogados = ColetarAdvogados();
                    if(novosAdvogados == default)
                        continue;
                    foreach (Advogado advogado in novosAdvogados){
                        RelacaoCasoAdvogado relacao = new(caso, advogado);
                        RelacaoCasoAdvogado.listaCasoAdvogados.Add(relacao);
                    }
                    break;
                case "2":
                    if(advogadosNoCaso.Count == 1){
                        App.Cx_Msg("Pelo menos um advogado precisa ser designado ao caso");
                        continue;
                    }
                    RemoverAssociacaoAdvogadoCaso(caso);
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    public static void RemoverAssociacaoAdvogadoCaso(CasoJuridico caso){
        Console.WriteLine("Informe o cna do advogado que deseja remover:");
        string cna = App.LerString();

        RelacaoCasoAdvogado? associacaoParaRemover = RelacaoCasoAdvogado.listaCasoAdvogados.FirstOrDefault(a =>
            a.Advogado.Cna.Equals(cna) && a.Caso.Equals(caso));

        if (associacaoParaRemover != null){
            RelacaoCasoAdvogado.listaCasoAdvogados.Remove(associacaoParaRemover);
            Console.WriteLine("Advogado removido com sucesso.");
        }
        else
            Console.WriteLine("Associação não encontrada.");

        Console.ReadLine();
    }


    public static void AlterarStatus(CasoJuridico caso){
        while (true){
            App.LimparTela();
            Console.WriteLine($"Data de abertura: {caso.DataInicio.ToShortDateString}");
            Console.WriteLine("\nSelecione o novo status:");
            Console.WriteLine("1. Concluído");
            Console.WriteLine("2. Arquivado");
            Console.WriteLine("0. Retornar ao menu anterior");

            Console.Write("-> ");
            string escolha = App.LerString();
            DateTime data;

            switch (escolha){
                case "1":
                    do{
                        Console.WriteLine("Informe a data de encerramento!");
                        data = App.LerData();
                        if(caso.DataInicio > data)
                            break;
                        Console.WriteLine("A data de encerramento deve ser posterior a de abertura!");
                    } while (true);
                    caso.DataEncerramento = data;
                    caso.Status = "Concluído";
                    Console.WriteLine("Status alterado para Concluído.");
                    break;
                case "2":
                    do{
                        Console.WriteLine("Informe a data de encerramento!");
                        data = App.LerData();
                        if(caso.DataInicio > data)
                            break;
                        Console.WriteLine("A data de encerramento deve ser posterior a de abertura!");
                    } while (true);
                    caso.DataEncerramento = data;
                    caso.Status = "Arquivado";
                    Console.WriteLine("Status alterado para Arquivado.");
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

            Console.ReadLine(); // Apenas para aguardar uma tecla antes de voltar ao menu.
        }
    }

    private static void InserirCusto(CasoJuridico caso){
        App.LimparTela();
        Console.Write("Informe o valor do custo: ");
        if (float.TryParse(Console.ReadLine(), out float valor)){
            Console.Write("Informe a descrição do custo: ");
            string descricao = App.LerString();

            try{
                caso.AdicionarCusto(valor, descricao);
            }catch(InvalidOperationException e){
                App.Cx_Msg(e.Message);
            }
        }else
            Console.WriteLine("Valor de custo inválido.");

        App.Pause();
    }

    private static void RemoverCusto(CasoJuridico caso){
        App.LimparTela();
        Console.Write("Informe o valor do custo: ");
        if (float.TryParse(Console.ReadLine(), out float valor)){
            Console.Write("Informe a descrição do custo: ");
            string descricao = App.LerString();

            try{
                caso.RemoverCusto(valor, descricao);
            }catch(InvalidOperationException e){
                App.Cx_Msg(e.Message);
            }
        }else
            Console.WriteLine("Valor de custo inválido.");

        App.Pause();
    }


    private static List<Advogado>? ColetarAdvogados(){
        App.LimparTela();
        Console.WriteLine("Digite o cna do advogado resposável pelo caso:");
        string cna = App.LerString();
        Advogado? advogado = Advogados.FirstOrDefault(a => a.Cna == cna);
        List<Advogado> advogadosNoCaso = new();

        while(advogado == default){
            Console.WriteLine("Advogado não encontrado!");
            Console.WriteLine("Deseja tentar novamente? [S] / [N]");
            cna = App.LerString();
            if(cna.ToUpper() == "N")
                return default;
            App.LimparTela();
            Console.WriteLine("Digite o cna do advogado resposável pelo caso:");
            cna = App.LerString();
            advogado = Advogados.FirstOrDefault(a => a.Cna == cna);
        }

        advogadosNoCaso.Add(advogado);

        while (true){
            App.LimparTela();
            Console.WriteLine("Deseja adicionar mais advogados ao caso? [S] / [N]");
            string resposta = App.LerString().ToUpper();

            if (resposta == "N")
                break;

            Console.WriteLine("Digite o cna do próximo advogado:");
            cna = App.LerString();
            advogado = Advogados.FirstOrDefault(a => a.Cna == cna);

            if (advogado == default){
                App.Cx_Msg("Advogado não encontrado!");
                continue;
            }

            advogadosNoCaso.Add(advogado);
        }
        return advogadosNoCaso;
    }

    private static Documento ColetarDocumento(){
        Console.WriteLine("Informe o tipo do documento do caso:");
        string tipo = App.LerString();
        
        int codigo = App.LerNumeroInteiro("Informe o código do documento:");

        Console.WriteLine("Informe a data de modificação do documento:");
        DateTime data = App.LerData();

        Console.WriteLine("Informe a descrição do documento:");
        string descricao = App.LerString();

        Documento documento = new(data, codigo, tipo, descricao);
        return documento;
    }

    private static List<(float, string)> ColetarCustos(){
        List<(float, string)> custos = new List<(float, string)>();

        while (true){
            Console.WriteLine("Informe o valor do custo:");
            float valor;
            while (!float.TryParse(App.LerString(), out valor))
                Console.WriteLine("Valor inválido. Tente novamente.");

            Console.WriteLine("Informe a descrição do custo:");
            string descricao = App.LerString();

            custos.Add((valor, descricao));

            Console.WriteLine("Deseja adicionar mais custos? [S] / [N]");
            string resposta = App.LerString().ToUpper();
            if (resposta != "S")
                break;
        }
        return custos;
    }

}