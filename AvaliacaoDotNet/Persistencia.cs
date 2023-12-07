using System.Text.Json;

namespace AvaliacaoDotNet
{
    public class Persistencia
    {

        public static void CarregarArquivosAdvogado(List<Advogado> listaAdvogados)
        {
            listaAdvogados.Clear();
            string caminhoArquivo = Path.Combine("C:/Users/alber/OneDrive/Documentos/ProjetosResidencia/equipe5-dotnet/AvaliacaoDotNet/BancoDeDados/dadosadvogados.txt");

            try
            {
                using (StreamReader reader = new StreamReader(caminhoArquivo))
                {
                    while (!reader.EndOfStream)
                    {
                        string linha = reader.ReadLine()!;
                        string[] dados = linha.Split(',');

                        // Certifique-se de que existam dados suficientes na linha
                        if (dados.Length >= 5)
                        {
                            string nome = dados[0];
                            DateTime dataNascimento = DateTime.Parse(dados[1]);
                            string cpf = dados[2];
                            string cna = dados[3];
                            string especialidade = dados[4];
                            listaAdvogados.Add(new Advogado(nome, dataNascimento, cpf, cna, especialidade));
                        }
                        else
                        {
                            App.LimparTela();
                            Console.Write("\n\tA linha no arquivo não contém dados suficientes para um Advogado.");
                        }
                    }
                }

                App.LimparTela();
                Console.Write("\n\tDados dos advogados carregados com sucesso.");
            }
            catch (Exception ex)
            {
                App.LimparTela();
                Console.Write($"\n\tOcorreu um erro ao carregar o arquivo de advogados: {ex.Message}");
            }
            App.Pause();
        }

        public static void CarregarArquivosCliente(List<Cliente> listaClientes)
        {
            listaClientes.Clear();
            string caminhoArquivo = Path.Combine("C:/Users/alber/OneDrive/Documentos/ProjetosResidencia/equipe5-dotnet/AvaliacaoDotNet/BancoDeDados/dadosclientes.txt");

            try
            {
                using (StreamReader reader = new StreamReader(caminhoArquivo))
                {
                    while (!reader.EndOfStream)
                    {
                        string linha = reader.ReadLine()!;

                        // Verifique se a linha é nula (fim do arquivo)
                        if (linha != null)
                        {
                            string[] dados = linha.Split(',');

                            // Certifique-se de que existam dados suficientes na linha
                            if (dados.Length >= 5)
                            {
                                string nome = dados[0];
                                string cpf = dados[1];
                                DateTime dataNascimento = DateTime.Parse(dados[2]);
                                string estadoCivil = dados[3];
                                string profissao = dados[4];
                                listaClientes.Add(new Cliente(nome, cpf, dataNascimento, estadoCivil, profissao));
                            }
                            else
                            {
                                Console.Write($"\n\tA linha no arquivo não contém dados suficientes para um Cliente. Linha: {linha}");
                            }
                        }
                        else
                        {
                            Console.Write("\n\tA linha lida é nula (fim do arquivo).");
                        }
                    }
                }

                Console.Write("\n\tDados dos clientes carregados com sucesso.");
            }
            catch (Exception ex)
            {
                Console.Write($"\n\tOcorreu um erro ao carregar o arquivo de clientes: {ex.Message}");
            }
            App.Pause();
        }

        public static void SalvarArquivosCliente(List<Cliente> listaClientes)
        {
            string caminhoArquivo = Path.Combine("C:/Users/alber/OneDrive/Documentos/ProjetosResidencia/equipe5-dotnet/AvaliacaoDotNet/BancoDeDados/dadosclientes.txt");

            try
            {
                using (StreamWriter arquivo = new StreamWriter(caminhoArquivo))
                {
                    foreach (Cliente cliente in listaClientes)
                    {
                        // Formatando os dados para gravar no arquivo
                        string linha = $"{cliente.Nome},{cliente.Cpf},{cliente.DataNascimento.ToShortDateString()},{cliente.EstadoCivil},{cliente.Profissao}";
                        arquivo.WriteLine(linha);
                    }
                }

                Console.WriteLine("\n\tDados dos clientes foram salvos com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\tOcorreu um erro ao salvar os dados dos clientes: {ex.Message}");
            }
            App.Pause();
        }

        public static void SalvarArquivosAdvogado(List<Advogado> listaAdvogados)
        {
            string caminhoArquivo = Path.Combine("C:/Users/alber/OneDrive/Documentos/ProjetosResidencia/equipe5-dotnet/AvaliacaoDotNet/BancoDeDados/dadosadvogados.txt");

            try
            {
                using (StreamWriter arquivo = File.CreateText(caminhoArquivo))
                {
                    foreach (Advogado advogado in listaAdvogados)
                    {
                        arquivo.WriteLine($"{advogado.Nome},{advogado.DataNascimento.ToShortDateString()},{advogado.Cpf},{advogado.Cna},{advogado.Especialidade}");
                    }
                }

                Console.Write("\n\tDados dos advogados foram salvos com sucesso!");
            }
            catch (Exception ex)
            {
                Console.Write($"\n\tOcorreu um erro ao salvar os dados dos advogados: {ex.Message}");
            }
        }

    }
}