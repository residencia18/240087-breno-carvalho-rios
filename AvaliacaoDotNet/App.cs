using System;
using System.IO;
using System.Collections.Generic;

namespace AvaliacaoDotNet
{
    public class App
    {
        public static void MainTechAdvocacia()
        {
            LimparTela();
            ListaCliente clientes = new ListaCliente();
            ListaAdvogado advogados = new ListaAdvogado();
            Persistencia persistencia = new Persistencia();
            CasoJuridico Juridico = new CasoJuridico();
            Relatorios relatorios = new Relatorios(clientes, advogados);
            persistencia.CarregarArquivosCliente(clientes);
            persistencia.CarregarArquivosAdvogado(advogados);
            EscritórioTechAdvocacia(clientes, advogados, persistencia, relatorios, Juridico);
        }
        public static int MenuClienteOuAdvogado()
        {
            int opcao = -1;
            do
            {
                LimparTela();
                DataHoraAtual();
                Console.WriteLine("\t===== TECH ADVOCACIA =====");
                Console.WriteLine("\t[1] - CLIENTE");
                Console.WriteLine("\t[2] - ADVOGADO");
                Console.WriteLine("\t[3] - JURÍDICO/PROCESSO");
                Console.WriteLine("\t[0] - SAIR");
                Console.Write("\tENTRADA -> ");
                string userInput = Console.ReadLine()!;

                if (!string.IsNullOrEmpty(userInput) && Int32.TryParse(userInput, out opcao))
                {
                    // A conversão foi bem-sucedida
                    if (opcao < 0 || opcao > 3)
                    {
                        Console.WriteLine("\n\tOpção inválida. Por favor, escolha uma opção de 0 a 3.");
                        Pause();
                    }
                }
                else
                {
                    Console.WriteLine("\n\tEntrada inválida. Por favor, insira um número válido.");
                    Pause();
                }

                if (opcao == 0)
                {
                    Console.Write("\n\tSaindo...");
                    Pause();
                    Environment.Exit(0);
                }

            } while (opcao > 3 || opcao < 0);

            return opcao;

        }
        public static int MenuJuridico()
        {
            int opcao = -1;
            do
            {
                LimparTela();
                DataHoraAtual();
                Console.WriteLine("\t========== TECH ADVOCACIA ==========");
                Console.WriteLine("\t[1] - CADASTRAR JURÍDICO/PROCESSO");
                Console.WriteLine("\t[2] - LISTAR JURÍDICO/PROCESSO");
                Console.WriteLine("\t[3] - CONCLUSÃO DO CASO JURÍDICO/PROCESSO");
                Console.WriteLine("\t[4] - CUSTO TOTAL DO CASO JURÍDICO/PROCESSO");
                Console.WriteLine("\t[5] - STATUS DO CASO JURÍDICO/PROCESSO");
                Console.WriteLine("\t[6] - RELATÓRIOS JURÍDICO/PROCESSO");
                Console.WriteLine("\t[7] - RETORNAR AO MENU PRINCIPAL");
                Console.WriteLine("\t[0] - SAIR");
                Console.Write("\tENTRADA -> ");
                string userInput = Console.ReadLine()!;

                if (!string.IsNullOrEmpty(userInput) && Int32.TryParse(userInput, out opcao))
                {
                    // A conversão foi bem-sucedida
                    if (opcao < 0 || opcao > 7)
                    {
                        Console.WriteLine("\n\tOpção inválida. Por favor, escolha uma opção de 0 a 7.");
                        Pause();
                    }
                }
                else
                {
                    Console.WriteLine("\n\tEntrada inválida. Por favor, insira um número válido.");
                    Pause();
                }

            } while (opcao > 7 || opcao < 0);

            return opcao;

        }
        public static int MenuEscritorio()
        {
            int opcao = -1;
            do
            {
                LimparTela();
                DataHoraAtual();
                Console.WriteLine("\t===== ESCRITORIO TECH ADVOCACIA =====");
                Console.WriteLine("\t[1] - CADASTRAR");
                Console.WriteLine("\t[2] - LISTAR");
                Console.WriteLine("\t[3] - EDITAR");
                Console.WriteLine("\t[4] - REMOVER");
                Console.WriteLine("\t[5] - PESQUISAR");
                Console.WriteLine("\t[6] - RELATÓRIOS");
                Console.WriteLine("\t[7] - RETORNAR AO MENU PRINCIPAL");
                Console.WriteLine("\t[0] - SAIR");
                Console.Write("\tENTRADA -> ");
                string userInput = Console.ReadLine()!;


                if (!string.IsNullOrEmpty(userInput) && Int32.TryParse(userInput, out opcao))
                {
                    // A conversão foi bem-sucedida
                    if (opcao < 0 || opcao > 7)
                    {
                        Console.WriteLine("\n\tOpção inválida. Por favor, escolha uma opção de 0 a 7.");
                        Pause();
                    }
                }
                else
                {
                    Console.WriteLine("\n\tEntrada inválida. Por favor, insira um número válido.");
                    Pause();
                }

                if (opcao == 0)
                {
                    Console.Write("\n\tSaindo...");
                    Pause();
                    Environment.Exit(0);
                }

            } while (opcao > 7 || opcao < 0);

            return opcao;
        }
        public static void EscritórioTechAdvocacia(ListaCliente clientes, ListaAdvogado advogados, Persistencia persistencia, Relatorios relatorios, CasoJuridico Juridico)
        {
            int opcao = 0;

            do
            {
                opcao = MenuClienteOuAdvogado();

                if (opcao == 1)
                {

                    do
                    {
                        opcao = MenuEscritorio();

                        switch (opcao)
                        {
                            case 1:
                                LimparTela();
                                clientes.Cadastrar();
                                persistencia.SalvarArquivosCliente(clientes);
                                break;

                            case 2:
                                LimparTela();
                                clientes.Listar();
                                Pause();
                                break;

                            case 3:
                                LimparTela();
                                clientes.Editar();
                                break;

                            case 4:
                                LimparTela();
                                clientes.Excluir();
                                break;

                            case 5:
                                LimparTela();
                                clientes.Pesquisar();
                                break;

                            case 6:
                                LimparTela();
                                relatorios.MenuRelatorios();
                                break;

                            case 7:
                                LimparTela();
                                EscritórioTechAdvocacia(clientes, advogados, persistencia, relatorios, Juridico);
                                break;

                            case 0:
                                Console.Write("\n\tSaindo...");
                                Pause();
                                Environment.Exit(0);
                                break;

                            default:
                                Console.WriteLine("\n\tOpção inválida. Por favor, escolha uma opção de 0 a 7.");
                                Pause();
                                break;
                        }

                    } while (opcao != 0);
                }
                else
                {
                    if (opcao == 2)
                    {
                        do
                        {
                            opcao = MenuEscritorio();

                            switch (opcao)
                            {
                                case 1:
                                    LimparTela();
                                    advogados.Cadastrar();
                                    persistencia.SalvarArquivosAdvogado(advogados);
                                    break;

                                case 2:
                                    LimparTela();
                                    advogados.Listar();
                                    Pause();
                                    break;

                                case 3:
                                    LimparTela();
                                    // advogados.Editar();
                                    Pause();
                                    break;

                                case 4:
                                    LimparTela();
                                    advogados.Excluir();
                                    break;

                                case 5:
                                    LimparTela();
                                    advogados.Pesquisar();
                                    break;

                                case 6:
                                    LimparTela();
                                    relatorios.MenuRelatorios();
                                    break;

                                case 7:
                                    LimparTela();
                                    EscritórioTechAdvocacia(clientes, advogados, persistencia, relatorios, Juridico);
                                    break;

                                case 0:
                                    Console.Write("\n\tSaindo...");
                                    Pause();
                                    Environment.Exit(0);
                                    break;

                                default:
                                    Console.WriteLine("\n\tOpção inválida. Por favor, escolha uma opção de 0 a 7.");
                                    Pause();
                                    break;
                            }

                        } while (opcao != 0);

                    }
                    else
                    {
                        if (opcao == 3)
                        {
                            do
                            {
                                opcao = MenuJuridico();

                                switch (opcao)
                                {
                                    case 1:
                                        LimparTela();
                                        Juridico.CadastrarCasoInterativo(clientes.GetClientes(), advogados.GetAdvogados());
                                        break;

                                    case 2:
                                        LimparTela();
                                        Juridico.ListarTodosOsCasos();
                                        Pause();
                                        break;

                                    case 3:
                                        // Juridico.ConclusaoDoCaso();
                                        break;

                                    case 4:
                                        // Juridico.CustoTotalDoCaso();
                                        break;

                                    case 5:
                                        // Juridico.StatusDoCaso();
                                        break;

                                    case 6:
                                        relatorios.MenuRelatorios();
                                        break;

                                    case 7:
                                        LimparTela();
                                        EscritórioTechAdvocacia(clientes, advogados, persistencia, relatorios, Juridico);
                                        break;

                                    case 0:
                                        Console.Write("\n\tSaindo...");
                                        Pause();
                                        Environment.Exit(0);
                                        break;

                                    default:
                                        Console.WriteLine("\n\tOpção inválida. Por favor, escolha uma opção de 0 a 7.");
                                        Pause();
                                        break;
                                }

                            } while (opcao != 0);

                        }
                    }
                }

            } while (true);
        }
        public static void DataHoraAtual()
        {
            var data = DateTime.Now;
            var formatada = string.Format("\n\t{0:f}", data);
            Console.WriteLine(formatada);
            Console.WriteLine("\tFalta " + (365 - data.DayOfYear) + " dias para o fim do ano.\n");
        }
        public static void LimparTela()
        {
            Console.Clear(); // Windows

            if (Environment.OSVersion.Platform != PlatformID.Win32NT)
            {
                Console.Write("\u001b[2J\u001b[1;1H"); // Linux
            }
        }
        public static void Pause()
        {
            Console.Write("\n\tPressione Enter para continuar...");
            Console.ReadLine();
        }
    }
}