using System.Globalization;

namespace AvaliacaoDotNet;
public class App
{
    public static void MainTechAdvocacia()
    {

        Persistencia.CarregarArquivosAdvogado(RegistroGeral.Advogados);
        Persistencia.CarregarArquivosCliente(RegistroGeral.Clientes);

        int opcao;
        do
        {
            opcao = DispMain();
            switch (opcao)
            {
                case 1:
                    MenuCasoJuridico();
                    break;
                case 2:
                    MenuClientes();
                    break;
                case 3:
                    MenuAdvogados();
                    break;
                case 4:
                    MenuPlano();
                    break;
                case 5:
                    MenuRelatorios();
                    break;
                case 0:
                    Cx_Msg("Programa encerrado!");
                    break;
                default:
                    Cx_Msg("Selecione uma opção válida");
                    break;
            }

        } while (opcao != 0);
    }

    public static void MenuCasoJuridico()
    {
        int opcao;
        do
        {
            opcao = DispMenuCasoJuridico();
            switch (opcao)
            {
                case 1:
                    RegistroGeral.NovoCaso();
                    break;
                case 2:
                    RegistroGeral.BuscarCaso();
                    break;
                case 0:
                    break;
                default:
                    Cx_Msg("Selecione uma opção válida");
                    break;
            }

        } while (opcao != 0);
    }

    public static void MenuClientes()
    {
        int opcao;
        do
        {
            opcao = DispMenuClientes();
            switch (opcao)
            {
                case 1:
                    try
                    {
                        RegistroGeral.NovoCliente();
                        Persistencia.SalvarArquivosCliente(RegistroGeral.Clientes);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Ocorreu um erro inesperado: {e.Message}");
                    }
                    break;
                case 2:
                    RegistroGeral.ExibirClientes();
                    break;
                case 3:
                    RegistroGeral.BuscarCliente();
                    Persistencia.SalvarArquivosCliente(RegistroGeral.Clientes);
                    break;
                case 0:
                    break;
                default:
                    Cx_Msg("Selecione uma opção válida");
                    break;
            }

        } while (opcao != 0);
    }

    public static void MenuPlano()
    {

        int opcao;
        do
        {
            opcao = DispMenuPlano();
            switch (opcao)
            {
                case 1:
                    try
                    {
                        RegistroGeral.NovoPlano();
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Ocorreu um erro inesperado: {e.Message}");
                    }
                    break;
                case 2:
                    RegistroGeral.ExibirPlanos();
                    break;
                case 3:
                    RegistroGeral.RemoverPlano();
                    break;
                case 4:
                    RegistroGeral.BuscarPlano();
                    break;
                case 0:
                    break;
                default:
                    Cx_Msg("Selecione uma opção válida");
                    break;
            }

        } while (opcao != 0);
    }

    public static void MenuAdvogados()
    {
        int opcao;
        do
        {
            opcao = DispMenuAdvogados();
            switch (opcao)
            {
                case 1:
                    try
                    {
                        RegistroGeral.NovoAdvogado();
                        Persistencia.SalvarArquivosAdvogado(RegistroGeral.Advogados);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Ocorreu um erro inesperado: {e.Message}");
                    }
                    break;
                case 2:
                    RegistroGeral.ExibirAdvogados();
                    break;
                case 3:
                    RegistroGeral.BuscarAdvogado();
                    Persistencia.SalvarArquivosAdvogado(RegistroGeral.Advogados);
                    break;
                case 0:
                    break;
                default:
                    Cx_Msg("Selecione uma opção válida");
                    break;
            }

        } while (opcao != 0);
    }

    public static void MenuRelatorios()
    {
        int opcao;
        do
        {
            opcao = DispMenuRelatorios();
            switch (opcao)
            {
                case 1:
                    Relatorios.RelatorioAdvogadosIdadeEntreDoisValores(RegistroGeral.Advogados);
                    break;
                case 2:
                    Relatorios.RelatorioClientesIdadeEntreDoisValores(RegistroGeral.Clientes);
                    break;
                case 3:
                    Relatorios.RelatorioEstadoCivilInformadoPeloUsuario(RegistroGeral.Clientes);
                    break;
                case 4:
                    Relatorios.RelatorioClienteEmOrdemAlfabetica(RegistroGeral.Clientes);
                    break;
                case 5:
                    Relatorios.RelatorioClientesCujaProfissaoContenhaTexto(RegistroGeral.Clientes);
                    break;
                case 6:
                    Relatorios.RelatorioAdvogadosEClientesAniversariantesDoMes(RegistroGeral.Advogados, RegistroGeral.Clientes);
                    break;
                case 7:
                    Relatorios.RelatorioCasosEmAbertoOrdemCrescente(RegistroGeral.Casos);
                    break;
                case 8:
                    Relatorios.AdvogadosOrdemDecrescenteCasosConcluidos(RelacaoCasoAdvogado.listaCasoAdvogados);
                    break;
                case 9:
                    Relatorios.RelatorioCasosCujaDescricaoCustoContenhaTexto(RegistroGeral.Casos);
                    break;
                case 10:
                    Relatorios.RelatorioTop10DocumentosMaisInseridos(RegistroGeral.Casos);
                    break;
                case 0:
                    break;
                default:
                    Cx_Msg("Selecione uma opção válida");
                    break;
            }

        } while (opcao != 0);
    }

    private static int DispMain()
    {
        int opcao = -1;
        do
        {
            LimparTela();
            DataHoraAtual();
            Console.WriteLine("\t===== TECH ADVOCACIA =====");
            Console.WriteLine("\t[1] - Gestão de Casos Jurídicos");
            Console.WriteLine("\t[2] - Gestão de Clientes");
            Console.WriteLine("\t[3] - Gestão de Advogados");
            Console.WriteLine("\t[4] - Gestão de Planos");
            Console.WriteLine("\t[5] - Relatórios");
            Console.WriteLine("\t[0] - Sair");
            Console.Write("\t-> ");
            string userInput = Console.ReadLine()!;

            if (string.IsNullOrEmpty(userInput) || !Int32.TryParse(userInput, out opcao))
            {
                Console.WriteLine("\n\tEntrada inválida. Por favor, insira um número válido.");
                Pause();
            }
        } while (opcao > 5 || opcao < 0);
        return opcao;
    }

    private static int DispMenuClientes()
    {
        int opcao = -1;
        do
        {
            LimparTela();
            DataHoraAtual();
            Console.WriteLine("\t===== TECH ADVOCACIA =====");
            Console.WriteLine("\t[1] - Cadastrar Novo Cliente");
            Console.WriteLine("\t[2] - Listar Todos os Clientes");
            Console.WriteLine("\t[3] - Buscar um Cliente");
            Console.WriteLine("\t[0] - Retornar ao Menu Anterior");
            Console.Write("\t-> ");
            string userInput = Console.ReadLine()!;

            if (string.IsNullOrEmpty(userInput) || !Int32.TryParse(userInput, out opcao))
            {
                Console.WriteLine("\n\tEntrada inválida. Por favor, insira um número válido.");
                Pause();
            }
        } while (opcao > 3 || opcao < 0);
        return opcao;
    }

    private static int DispMenuAdvogados()
    {
        int opcao = -1;
        do
        {
            LimparTela();
            DataHoraAtual();
            Console.WriteLine("\t===== TECH ADVOCACIA =====");
            Console.WriteLine("\t[1] - Cadastrar Novo Advogado");
            Console.WriteLine("\t[2] - Listar Todos os Advogados");
            Console.WriteLine("\t[3] - Buscar um Advogado");
            Console.WriteLine("\t[0] - Retornar ao Menu Anterior");
            Console.Write("\t-> ");
            string userInput = Console.ReadLine()!;

            if (string.IsNullOrEmpty(userInput) || !Int32.TryParse(userInput, out opcao))
            {
                Console.WriteLine("\n\tEntrada inválida. Por favor, insira um número válido.");
                Pause();
            }
        } while (opcao > 3 || opcao < 0);
        return opcao;
    }

    private static int DispMenuPlano()
    {
        int opcao = -1;
        do
        {
            LimparTela();
            DataHoraAtual();
            Console.WriteLine("\t===== TECH ADVOCACIA =====");
            Console.WriteLine("\t[1] - Cadastrar Novo Plano");
            Console.WriteLine("\t[2] - Listar Todos os Planos");
            Console.WriteLine("\t[3] - Remover um Plano");
            Console.WriteLine("\t[4] - Buscar um Plano");
            Console.WriteLine("\t[0] - Retornar ao Menu Anterior");
            Console.Write("\t-> ");
            string userInput = Console.ReadLine()!;

            if (string.IsNullOrEmpty(userInput) || !Int32.TryParse(userInput, out opcao))
            {
                Console.WriteLine("\n\tEntrada inválida. Por favor, insira um número válido.");
                Pause();
            }
        } while (opcao > 4 || opcao < 0);

        return opcao;
    }

    private static int DispMenuRelatorios()
    {
        int opcao = -1;
        do
        {
            LimparTela();
            DataHoraAtual();
            Console.WriteLine("\t================================ R E L A T Ó R I O S ================================");
            Console.WriteLine("\t[1] - Advogados com idade entre dois valores");
            Console.WriteLine("\t[2] - Clientes com idade entre dois valores");
            Console.WriteLine("\t[3] - Clientes com estado civil informado pelo usuário");
            Console.WriteLine("\t[4] - Clientes em ordem alfabética");
            Console.WriteLine("\t[5] - Clientes cuja profissão contenha texto informado pelo usuário");
            Console.WriteLine("\t[6] - Advogados e Clientes aniversariantes do mês informado");
            Console.WriteLine("\t[7] - Casos com o status “Em aberto”, em ordem crescente pela data de início");
            Console.WriteLine("\t[8] - Advogados em ordem decrescente pela quantidade de casos com status “Concluído”");
            Console.WriteLine("\t[9] - Casos que possuam custo com uma determinada palavra na descrição");
            Console.WriteLine("\t[10] -	Top 10 tipos de documentos mais inseridos nos casos.");
            Console.WriteLine("\t[0] - Retornar ao Menu Anterior");
            Console.Write("\t-> ");
            string userInput = Console.ReadLine()!;

            if (string.IsNullOrEmpty(userInput) || !Int32.TryParse(userInput, out opcao))
            {
                Console.WriteLine("\n\tEntrada inválida. Por favor, insira um número válido.");
                Pause();
            }
        } while (opcao > 10 || opcao < 0);
        return opcao;
    }

    private static int DispMenuCasoJuridico()
    {
        int opcao = -1;
        do
        {
            LimparTela();
            DataHoraAtual();
            Console.WriteLine("\t===== TECH ADVOCACIA =====");
            Console.WriteLine("\t[1] - Abrir um Novo Caso Jurídico");
            Console.WriteLine("\t[2] - Buscar um Caso Existente");
            Console.WriteLine("\t[0] - Retornar ao Menu Anterior");
            Console.Write("\t-> ");
            string userInput = Console.ReadLine()!;

            if (string.IsNullOrEmpty(userInput) || !Int32.TryParse(userInput, out opcao))
            {
                Console.WriteLine("\n\tEntrada inválida. Por favor, insira um número válido.");
                Pause();
            }
        } while (opcao > 2 || opcao < 0);
        return opcao;
    }

    public static DateTime LerData()
    {
        string? input;
        do
        {
            input = Console.ReadLine()?.Trim();
        } while (string.IsNullOrEmpty(input));

        string formato = "dd/MM/yyyy";

        if (!DateTime.TryParseExact(input, formato, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime resultado))
        {
            Console.WriteLine("Formato de data inválido!");
            return LerData();
        }

        return resultado;
    }
    public static string LerString()
    {
        string? input;
        do
        {
            Console.Write("\t");
            input = Console.ReadLine()?.Trim();
        } while (string.IsNullOrEmpty(input));

        return input;
    }
    public static int LerNumeroInteiro(string mensagem)
    {
        while (true)
        {
            Console.Write(mensagem);

            string input = Console.ReadLine()!;

            if (string.IsNullOrEmpty(input))
            {
                LimparTela();
                Console.WriteLine("\n\tEntrada inválida. Por favor, insira um valor numérico.");
                continue;
            }

            if (int.TryParse(input, out int valor))
                return valor;
            else
            {
                LimparTela();
                Console.WriteLine("\n\tEntrada inválida. Por favor, insira um valor numérico válido.");
            }
            Pause();
        }
    }
    public static void Cx_Msg(string texto)
    {
        LimparTela();
        Console.WriteLine(texto);
        Pause();
    }
    public static void DataHoraAtual()
    {
        var data = DateTime.Now;
        var formatada = string.Format("\n\t{0:f}", data);
        Console.WriteLine(formatada);
        Console.WriteLine("\tFalta " + (365 - data.DayOfYear) + " dias para o fim do ano.\n");
    }

    public static double LerDouble(string mensagem)
    {
        while (true)
        {
            Console.Write(mensagem);

            string input = Console.ReadLine()!;

            if (string.IsNullOrEmpty(input))
            {
                LimparTela();
                Console.WriteLine("\n\tEntrada inválida. Por favor, insira um valor numérico.");
                continue;
            }

            if (double.TryParse(input, out double valor))
                return valor;
            else
            {
                LimparTela();
                Console.WriteLine("\n\tEntrada inválida. Por favor, insira um valor numérico válido.");
            }
            Pause();
        }
    }

    public static void LimparTela()
    {
        Console.Clear(); // Windows
        if (Environment.OSVersion.Platform != PlatformID.Win32NT)
            Console.Write("\u001b[2J\u001b[1;1H"); // Linux
    }

    public static void Pause()
    {
        Console.Write("\n\tPressione Enter para continuar...");
        Console.ReadLine();
    }
}
