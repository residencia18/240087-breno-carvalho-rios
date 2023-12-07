namespace AvaliacaoDotNet
{
    public class Relatorios
    {
        public static void RelatorioClientesIdadeEntreDoisValores(List<Cliente> clientes)
        {
            App.LimparTela();
            Console.WriteLine("\n\t========== RELATÓRIO DE CLIENTES COM IDADE ENTRE DOIS VALORES ==========");

            int valorMinimo = App.LerNumeroInteiro("\n\tDigite o valor mínimo: ");

            int valorMaximo = App.LerNumeroInteiro("\n\tDigite o valor máximo: ");

            var clientesFiltrados = clientes.Where(cliente => cliente.Idade >= valorMinimo && cliente.Idade <= valorMaximo);

            if (clientesFiltrados.Any())
            {
                Console.WriteLine("\n\tCLIENTE ENCONTRADOS:");
                App.LimparTela();
                foreach (var cliente in clientesFiltrados)
                {
                    Console.WriteLine("\n\t=========== CLIENTE ===========");
                    Console.WriteLine(cliente.ToString());
                    Console.Write($"\t==========================");
                }
            }
            else
            {
                Console.WriteLine("\n\tNenhum cliente encontrado.");
            }

            App.Pause();
        }

        public static void RelatorioAdvogadosIdadeEntreDoisValores(List<Advogado> advogados)
        {
            App.LimparTela();
            Console.WriteLine("\n\t=== LISTA DE ADVOGADOS COM IDADE ENTRE DOIS VALORES ===");

            int valorMinimo = App.LerNumeroInteiro("\n\tDigite o valor mínimo: ");

            int valorMaximo = App.LerNumeroInteiro("\n\tDigite o valor máximo: ");

            var advogadosFiltrados = advogados.Where(advogado => advogado.Idade >= valorMinimo && advogado.Idade <= valorMaximo);

            App.LimparTela();
            foreach (Advogado advogado in advogadosFiltrados)
            {
                Console.WriteLine("\n\t=========== ADVOGADO ===========");
                Console.WriteLine(advogado.ToString());                
                Console.Write("\t==========================");
            }
            App.Pause();
        }

        public static void RelatorioEstadoCivilInformadoPeloUsuario(List<Cliente> clientes)
        {
            if (clientes == null)
            {
                Console.WriteLine("\n\tLista de clientes não fornecida. Retornando ao menu.");
                App.Pause();
                return;
            }

            App.LimparTela();
            Console.WriteLine("\n\t========== RELATÓRIO DE CLIENTES COM ESTADO CIVIL ==========");
            
            Console.Write("\n\tDigite o estado civil: ");
            string estadoCivil = Console.ReadLine()!;

            var clientesFiltrados = clientes.Where(cliente => cliente.EstadoCivil.ToLower() == estadoCivil.ToLower());

            if (clientesFiltrados.Any())
            {
                App.LimparTela();
                Console.WriteLine("\n\tCLIENTES ENCONTRADOS:");
                foreach (var cliente in clientesFiltrados)
                {
                    Console.WriteLine("\n\t=========== CLIENTE ===========");
                    Console.WriteLine(cliente.ToString());                    
                    Console.Write($"\t==========================");
                }
            }
            else
            {
                Console.WriteLine("\n\tNenhum cliente encontrado.");
            }

            App.Pause();
        }

        public static void RelatorioClienteEmOrdemAlfabetica(List<Cliente> clientes)
        {
            App.LimparTela();
            Console.WriteLine("\n\t========== RELATÓRIO DE CLIENTES EM ORDEM ALFABÉTICA ==========");

            var clientesOrdenados = clientes.OrderBy(cliente => cliente.Nome);

            if (clientesOrdenados.Count() > 0)
            {
                App.LimparTela();
                Console.WriteLine("\n\tCLIENTES ENCONTRADOS:");
                foreach (var cliente in clientesOrdenados)
                {
                    Console.WriteLine("\n\t=========== CLIENTE ===========");
                    Console.WriteLine(cliente.ToString());                    
                    Console.Write($"\t==========================");
                }
            }
            else
            {
                Console.WriteLine("\n\tNenhum paciente encontrado.");
            }

            App.Pause();
        }

        public static void RelatorioAdvogadoEmOrdemAlfabetica(List<Advogado> advogados)
        {
            App.LimparTela();
            Console.WriteLine("\n\t=== LISTA DE ADVOGADOS EM ORDEM ALFABÉTICA ===");

            var advogadosOrdenados = advogados.OrderBy(advogado => advogado.Nome);

            foreach (Advogado advogado in advogadosOrdenados)
            {
                Console.WriteLine("\n\t=========== ADVOGADO ===========");
                Console.WriteLine(advogado.ToString());
                Console.Write("\t==========================");
            }

            App.Pause();
        }

        public static void RelatorioClientesCujaProfissaoContenhaTexto(List<Cliente> clientes)
        {
            App.LimparTela();
            Console.WriteLine("\n\t========== RELATÓRIO DE CLIENTES CUJA A PROFISSÃO CONTENHA TEXTO ==========");

            Console.Write("\n\tDigite o texto: ");
            string texto = Console.ReadLine()!;

            var clientesFiltrados = clientes.Where(cliente => cliente.Profissao.ToLower().Contains(texto.ToLower()));

            if (clientesFiltrados.Count() > 0)
            {
                App.LimparTela();
                Console.WriteLine("\n\tCLIENTES ENCONTRADOS:");
                foreach (var cliente in clientesFiltrados)
                {
                    Console.WriteLine("\n\t=========== CLIENTE ===========");
                    Console.WriteLine(cliente.ToString());                    
                    Console.Write($"\t==========================");
                }
            }
            else
            {
                Console.WriteLine("\n\tNenhum cliente encontrado.");
            }

            App.Pause();
        }

        public static void RelatorioAdvogadosEClientesAniversariantesDoMes(List<Advogado> advogados, List<Cliente> clientes)
        {
            App.LimparTela();
            Console.WriteLine("\n\t========== ADVOGADOS E CLIENTES ANIVERSARIANTES DO MÊS ==========");

            int mes = App.LerNumeroInteiro("\n\tDigite o mês: ");

            if(mes < 1 || mes > 12){
                Console.WriteLine($"Mês Inválido!");                
                return;
            }

            var advogadosFiltrados = advogados.Where(advogado => advogado.DataNascimento.Month == mes);
            var clientesFiltrados = clientes.Where(cliente => cliente.DataNascimento.Month == mes);

            if (advogadosFiltrados.Count() > 0)
            {
                Console.WriteLine("\n\tADVOGADOS ANIVERSARIANTES DO MÊS:");
                foreach (var advogado in advogadosFiltrados)
                {
                    Console.WriteLine("\n\t=========== ADVOGADO ===========");
                    Console.WriteLine(advogado.ToString());                    
                    Console.Write($"\t==========================");
                }
                App.Pause();
            }
            else
            {
                Console.WriteLine("\n\tNenhum advogado encontrado.");
                App.Pause();
            }

            if (clientesFiltrados.Count() > 0)
            {
                App.LimparTela();
                Console.WriteLine("\n\t========== ADVOGADOS E CLIENTES ANIVERSARIANTES DO MÊS ==========");

                Console.WriteLine("\n\tCLIENTES ANIVERSARIANTES DO MÊS:");
                foreach (var cliente in clientesFiltrados)
                {
                    Console.WriteLine("\n\t=========== CLIENTE ===========");
                    Console.WriteLine(cliente.ToString());
                    Console.Write($"\t==========================");
                }
            }
            else
            {
                Console.WriteLine("\n\tNenhum cliente encontrado.");
                App.Pause();
            }

            App.Pause();
        }

        public static void RelatorioAdvogadoComIdadeMaiorQue(List<Advogado> advogados)
        {
            App.LimparTela();
            Console.WriteLine("\n\t=== Lista de Advogados com Idade Maior que ===");

            Console.Write("\n\tDigite a idade: ");
            int idade = int.Parse(Console.ReadLine()!);

            var advogadosFiltrados = advogados.Where(advogado => advogado.Idade > idade);

            App.LimparTela();
            foreach (Advogado advogado in advogadosFiltrados)
            {
                Console.WriteLine("\n\t=========== ADVOGADO ===========");
                Console.WriteLine("\tNome: " + advogado.Nome);
                Console.WriteLine("\tCPF: " + advogado.Cpf);
                Console.WriteLine("\tData de Nascimento: " + advogado.DataNascimento.ToString("dd/MM/yyyy"));
                Console.WriteLine("\tIdade: " + advogado.Idade);
                Console.WriteLine("\tCNA: " + advogado.Cna);
                Console.WriteLine("\tEspecialidade: " + advogado.Especialidade);
                Console.WriteLine("\t==========================\n");
            }

            App.Pause();
        }

        public static void RelatorioAdvogadoComIdadeMenorQue(List<Advogado> advogados)
        {
            App.LimparTela();
            Console.WriteLine("\n\t=== Lista de Advogados com Idade Menor que ===");

            Console.Write("\n\tDigite a idade: ");
            int idade = int.Parse(Console.ReadLine()!);

            var advogadosFiltrados = advogados.Where(advogado => advogado.Idade < idade);

            App.LimparTela();
            foreach (Advogado advogado in advogadosFiltrados)
            {
                Console.WriteLine("\n\t=========== ADVOGADO ===========");
                Console.WriteLine("\tNome: " + advogado.Nome);
                Console.WriteLine("\tCPF: " + advogado.Cpf);
                Console.WriteLine("\tData de Nascimento: " + advogado.DataNascimento.ToString("dd/MM/yyyy"));
                Console.WriteLine("\tIdade: " + advogado.Idade);
                Console.WriteLine("\tCNA: " + advogado.Cna);
                Console.WriteLine("\tEspecialidade: " + advogado.Especialidade);
                Console.WriteLine("\t==========================\n");
            }

            App.Pause();
        }

        public static void RelatorioAdvogadoComIdadeIgualA(List<Advogado> advogados)
        {
            App.LimparTela();
            Console.WriteLine("\n\t=== Lista de Advogados com Idade Igual a ===");

            Console.Write("\n\tDigite a idade: ");
            int idade = int.Parse(Console.ReadLine()!);

            var advogadosFiltrados = advogados.Where(advogado => advogado.Idade == idade);

            App.LimparTela();
            foreach (Advogado advogado in advogadosFiltrados)
            {
                Console.WriteLine("\n\t=========== ADVOGADO ===========");
                Console.WriteLine("\tNome: " + advogado.Nome);
                Console.WriteLine("\tCPF: " + advogado.Cpf);
                Console.WriteLine("\tData de Nascimento: " + advogado.DataNascimento.ToString("dd/MM/yyyy"));
                Console.WriteLine("\tIdade: " + advogado.Idade);
                Console.WriteLine("\tCNA: " + advogado.Cna);
                Console.WriteLine("\tEspecialidade: " + advogado.Especialidade);
                Console.WriteLine("\t==========================\n");
            }

            App.Pause();
        }

        public static void RelatorioAdvogadoComIdadeDiferenteDe(List<Advogado> advogados)
        {
            App.LimparTela();
            Console.WriteLine("\n\t=== Lista de Advogados com Idade Diferente de ===");

            Console.Write("\n\tDigite a idade: ");
            int idade = int.Parse(Console.ReadLine()!);

            var advogadosFiltrados = advogados.Where(advogado => advogado.Idade != idade);

            App.LimparTela();
            foreach (Advogado advogado in advogadosFiltrados)
            {
                Console.WriteLine("\n\t=========== ADVOGADO ===========");
                Console.WriteLine("\tNome: " + advogado.Nome);
                Console.WriteLine("\tCPF: " + advogado.Cpf);
                Console.WriteLine("\tData de Nascimento: " + advogado.DataNascimento.ToString("dd/MM/yyyy"));
                Console.WriteLine("\tIdade: " + advogado.Idade);
                Console.WriteLine("\tCNA: " + advogado.Cna);
                Console.WriteLine("\tEspecialidade: " + advogado.Especialidade);
                Console.WriteLine("\t==========================\n");
            }

            App.Pause();
        }

        public static void RelatorioAdvogadoComIdadeMaiorOuIgualA(List<Advogado> advogados)
        {
            App.LimparTela();
            Console.WriteLine("\n\t=== Lista de Advogados com Idade Maior ou Igual a ===");

            Console.Write("\n\tDigite a idade: ");
            int idade = int.Parse(Console.ReadLine()!);

            var advogadosFiltrados = advogados.Where(advogado => advogado.Idade >= idade);

            App.LimparTela();
            foreach (Advogado advogado in advogadosFiltrados)
            {
                Console.WriteLine("\n\t=========== ADVOGADO ===========");
                Console.WriteLine("\tNome: " + advogado.Nome);
                Console.WriteLine("\tCPF: " + advogado.Cpf);
                Console.WriteLine("\tData de Nascimento: " + advogado.DataNascimento.ToString("dd/MM/yyyy"));
                Console.WriteLine("\tIdade: " + advogado.Idade);
                Console.WriteLine("\tCNA: " + advogado.Cna);
                Console.WriteLine("\tEspecialidade: " + advogado.Especialidade);
                Console.WriteLine("\t==========================\n");
            }

            App.Pause();
        }

        public static void RelatorioCasosEmAbertoOrdemCrescente(List<CasoJuridico> casosJuridicos)
        {
            App.LimparTela();
            Console.WriteLine("\n\t=== Lista de Casos com o status “Em aberto”, em ordem crescente pela data de início ===");

            var casosJuridicosFiltrados = casosJuridicos.Where(caso => caso.Status.ToLower() == "em aberto")
                .OrderBy(caso => caso.DataInicio);

            App.LimparTela();   

            if (casosJuridicosFiltrados.Count() > 0)
            {
                Console.WriteLine("\n\tCASOS JURÍDICOS ENCONTRADOS:");
                foreach (var caso in casosJuridicosFiltrados)
                {
                    Console.WriteLine("\n\t=========== CASO JURÍDICO ===========");
                    Console.WriteLine(caso.ToString());                    
                    Console.Write($"\t==========================");
                }
            }
            else
            {
                Console.WriteLine("\n\tNenhum caso jurídico encontrado.");
            }

            App.Pause();
        }

        public static void AdvogadosOrdemDecrescenteCasosConcluidos(List<RelacaoCasoAdvogado> relacaoCasoAdvogado) {
            App.LimparTela();
            Console.WriteLine("\n\t========== Lista de Advogados em ordem decrescente de casos concluídos ==========");

            var listaAdvogados = relacaoCasoAdvogado
                .Where(relacao => relacao.Caso.Status.ToLower() == "concluido")
                .GroupBy(relacao => relacao.Advogado.Nome)
                .Select(grupo => new { NomeAdvogado = grupo.Key, QuantidadeCasosConcluidos = grupo.Count() })
                .OrderByDescending(resultado => resultado.QuantidadeCasosConcluidos)
                .ToList();
            
            if (listaAdvogados.Count() > 0)
            {
                App.LimparTela();
                Console.WriteLine("\n\tLISTA DE ADVOGADOS EM ORDEM DECRESCENTE DE CASOS CONCLUÍDOS:");
                foreach (var advogado in listaAdvogados)
                {
                    Console.WriteLine("\n\t=========== ADVOGADO ===========");
                    Console.WriteLine(advogado.ToString());                    
                    Console.Write($"\t==========================");
                }
            }
            else
            {
                Console.WriteLine("\n\tNenhum advogado encontrado.");
            }

            App.Pause();
        }

        public static void RelatorioCasosCujaDescricaoCustoContenhaTexto(List<CasoJuridico> casosJuridicos)
        {
            App.LimparTela();
            Console.WriteLine("\n\t========== Lista de Casos que possuam custo com uma determinada palavra na descrição ==========");

            Console.Write("\n\tDigite o texto: ");
            string texto = Console.ReadLine()!;
            
            var casosJuridicosFiltrados = casosJuridicos.Where(
                caso => caso.Custos.Any(
                    custo => custo.Item2.ToLower().Contains(texto.ToLower())
                )
            ).ToList();

            if (casosJuridicosFiltrados.Count() > 0)
            {
                App.LimparTela();
                Console.WriteLine("\n\tCASOS JURÍDICOS ENCONTRADOS:");
                foreach (var caso in casosJuridicosFiltrados)
                {
                    Console.WriteLine("\n\t=========== CASO JURÍDICO ===========");
                    Console.WriteLine(caso.ToString());                    
                    Console.Write($"\t==========================");
                }
            }
            else
            {
                Console.WriteLine("\n\tNenhum caso jurídico encontrado.");
            }

            App.Pause();
        }

        public static void RelatorioTop10DocumentosMaisInseridos(List<CasoJuridico> casosJuridicos)
        {
            App.LimparTela();
            Console.WriteLine("\n\t========== Top 10 tipos de documentos mais inseridos nos casos ==========");;
            
            var topDezTipos = casosJuridicos.SelectMany(caso => caso.Documentos)
                .GroupBy(documento => documento.Tipo)
                .Select(grupo => new { TipoDocumento = grupo.Key, Contagem = grupo.Count() })
                .OrderByDescending(resultado => resultado.Contagem)
                .Take(10)
                .ToList();

            if (topDezTipos.Count() > 0)
            {
                App.LimparTela();
                Console.WriteLine("\n\tTOP 10 TIPOS:");
                foreach (var documento in topDezTipos)
                {
                    Console.WriteLine("\n\t=========== TIPO ===========");
                    Console.WriteLine($"Tipo: {documento.TipoDocumento} - Quantidade: {documento.Contagem}");
                    Console.Write($"\t==========================");
                }
            }
            else
            {
                Console.WriteLine("\n\tNenhum documento encontrado.");
            }

            App.Pause();
        }
    }
}