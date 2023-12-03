using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.Collections;

namespace AvaliacaoDotNet
{
    public class CasoJuridico
    {
        public DateTime DataInicio { get; set; }
        public float ProbabilidadeSucesso { get; set; }
        public string Status { get; set; }
        public List<(float, string)> Custos { get; set; }
        public DateTime? DataEncerramento { get; set; }
        public Cliente Cliente { get; set; }
        public List<Documento> Documentos { get; set; }
        public List<Advogado> Advogados { get; set; }
        public List<CasoJuridico> casos { get; set; }

        public CasoJuridico()
        {
            Documentos = new List<Documento>();
            Custos = new List<(float, string)>();
            Advogados = new List<Advogado>();
            casos = new List<CasoJuridico>();
            Status = "Em aberto";
        }

        public void AdicionarCaso(CasoJuridico caso)
        {
            casos.Add(caso);
        }

        public List<CasoJuridico> GetCasos()
        {
            return casos;
        }

        public void IniciarCaso()
        {
            DataInicio = DateTime.Now;
            Status = "Em aberto";
            App.LimparTela();
            Console.WriteLine("\n\tCaso iniciado com sucesso!");
            App.Pause();
        }

        public void CadastrarCaso(Cliente cliente, float probabilidadeSucesso, List<Advogado> advogados, List<Documento> documentos, List<(float, string)> custos)
        {

            if (cliente == null)
            {
                throw new ArgumentNullException(nameof(cliente), "O cliente não pode ser nulo.");
            }

            if (advogados == null || advogados.Count == 0)
            {
                throw new ArgumentException("É necessário fornecer pelo menos um advogado.");
            }

            Cliente = cliente;
            ProbabilidadeSucesso = probabilidadeSucesso;

            if (documentos != null)
            {
                Documentos.AddRange(documentos);
            }

            if (custos != null)
            {
                Custos.AddRange(custos);
            }

            // Adiciona os advogados fornecidos à lista de advogados
            Advogados.AddRange(advogados);

            // O caso é automaticamente iniciado ao ser cadastrado
            IniciarCaso();
        }

        public void CadastrarCasoInterativo(List<Cliente> clientesCadastrados, List<Advogado> advogadosCadastrados)
        {

            try
            {
                Console.WriteLine("\n\t========== CADASTRO DE CASO JURÍDICO ==========");

                Cliente cliente;
                string cpfCliente;
                do
                {
                    App.LimparTela();
                    Console.Write("\n\tDigite o CPF do cliente: ");
                    cpfCliente = Console.ReadLine()!;

                    cliente = clientesCadastrados.FirstOrDefault(c => c.Cpf == cpfCliente);

                    if (!Cliente.IsValidCPF(cpfCliente) || cliente == null)
                    {
                        App.LimparTela();
                        Console.WriteLine("\n\tOps, CPF inválido ou Cliente não encontrado. Por favor, cadastre o cliente antes de prosseguir.");
                        App.Pause();
                    }

                } while (!Cliente.IsValidCPF(cpfCliente));

                Console.Write("\n\tDigite a probabilidade de sucesso (0 a 10): ");
                float probabilidadeSucesso;

                while (!float.TryParse(Console.ReadLine(), out probabilidadeSucesso) || probabilidadeSucesso < 0 || probabilidadeSucesso > 10)
                {
                    Console.WriteLine("\n\tPor favor, digite um valor válido entre 0 e 10.");
                }

                App.LimparTela();
                List<Advogado> advogados = new List<Advogado>();
                Console.WriteLine("\n\tSolicitando informações dos advogados:");

                Advogado advogado;
                int cnaAdvogado;

                do
                {
                    cnaAdvogado = Cliente.LerNumeroInteiro("\n\tDigite o CNA do advogado ou [0] para Sair: ");

                    if (cnaAdvogado == 0)
                    {
                        Console.WriteLine("\n\tCadastro de advogados finalizado, retornando ao menu principal.");
                        break;
                    }

                    advogado = advogadosCadastrados.FirstOrDefault(a => a.Cna == cnaAdvogado);

                    if (advogado == null)
                    {
                        App.LimparTela();
                        Console.WriteLine("\n\tOps, CNA não encontrado. Por favor, cadastre o advogado antes de prosseguir.");
                        App.Pause();
                        continue;
                    }
                    else
                    {
                        advogados.Add(advogado);
                        break;
                    }

                } while (true);

                if (advogados.Count > 0)
                {
                    // Solicitando informações de documentos
                    List<Documento> documentos = SolicitarInformacoesDocumentos();

                    // Solicitando informações de custos
                    List<(float, string)> custos = SolicitarInformacoesCustos();

                    // Cadastrando o caso com as informações fornecidas pelo usuário
                    CadastrarCaso(cliente, probabilidadeSucesso, advogados, documentos, custos);

                    // Adicionando o caso à lista de casos
                    AdicionarCaso(this);  // "this" refere-se à instância atual da classe CasoJuridico

                    App.LimparTela();
                    Console.WriteLine("\n\tCaso cadastrado com sucesso!");
                    App.Pause();

                    ListarInformacoesCaso();
                }
                else
                {
                    Console.WriteLine("\n\tNenhum advogado cadastrado. O caso não foi cadastrado.");
                }
            }
            catch (Exception ex)
            {
                App.LimparTela();
                Console.WriteLine($"\n\tErro ao cadastrar caso: {ex.Message}");
            }
            App.Pause();
        }

        private List<Documento> SolicitarInformacoesDocumentos()
        {

            App.LimparTela();
            List<Documento> documentos = new List<Documento>();
            Console.WriteLine("\n\tSolicitando informações de documentos:");

            Console.WriteLine("\n\tA data de modificação será a data e hora atuais do sistema.");
            App.Pause();
            DateTime dataHoraModificacao = DateTime.Now;

            App.LimparTela();
            Console.Write("\n\tDigite o código do documento: ");
            int codigoDocumento;
            while (!int.TryParse(Console.ReadLine(), out codigoDocumento))
            {
                Console.WriteLine("\n\tPor favor, digite um valor inteiro válido para o código do documento.");
            }

            App.LimparTela();
            Console.Write("\n\tDigite o tipo do documento: ");
            string tipoDocumento = Console.ReadLine();

            Console.Write("\n\tDigite a descrição do documento: ");
            string descricaoDocumento = Console.ReadLine();

            Documento documento = new Documento
            {
                DataHoraModificacao = dataHoraModificacao,
                Codigo = codigoDocumento,
                Tipo = tipoDocumento,
                Descricao = descricaoDocumento
            };

            documentos.Add(documento);

            return documentos;
        }

        private List<(float, string)> SolicitarInformacoesCustos()
        {

            App.LimparTela();
            List<(float, string)> custos = new List<(float, string)>();
            Console.WriteLine("\n\tSolicitando informações de custos:");

            Console.Write("\n\tDigite o valor do custo: ");
            float valorCusto;

            while (!float.TryParse(Console.ReadLine(), out valorCusto) || valorCusto < 0)
            {
                Console.WriteLine("\n\tPor favor, digite um valor válido para o custo.");
            }

            Console.Write("\n\tDigite a descrição do custo: ");
            string descricaoCusto = Console.ReadLine();

            custos.Add((valorCusto, descricaoCusto));

            return custos;
        }

        public void AtualizarCaso(DateTime? dataEncerramento, List<Advogado> novosAdvogados)
        {

            if (casos == null || casos.Count == 0)
            {
                App.LimparTela();
                Console.WriteLine("\n\tNão há casos cadastrados.");
                return;
            }

            if (Status == "Em aberto" && dataEncerramento.HasValue)
            {
                throw new InvalidOperationException("Não é possível definir a data de encerramento enquanto o caso estiver em aberto.");
            }

            if (dataEncerramento.HasValue && dataEncerramento <= DataInicio)
            {
                throw new InvalidOperationException("A data de encerramento deve ser posterior à data de abertura.");
            }

            DataEncerramento = dataEncerramento;

            if (novosAdvogados != null && novosAdvogados.Count > 0)
            {
                Advogados.AddRange(novosAdvogados);
            }

            Status = DataEncerramento.HasValue ? "Concluído" : "Em aberto";
        }

        public void ListarInformacoesCaso()
        {

            if (Cliente == null || Advogados == null || Advogados.Count == 0 || Documentos == null || Documentos.Count == 0 || Custos == null || Custos.Count == 0)
            {
                App.LimparTela();
                string mensagemErro = "\n\n\tO caso não pode ser listado porque:\n";

                if (Cliente == null)
                    mensagemErro += "\n\tA lista de clientes não foi inicializada.\n";

                if (Advogados == null || Advogados.Count == 0)
                    mensagemErro += "\n\tA lista de advogados está vazia ou não foi inicializada.\n";

                if (Documentos == null || Documentos.Count == 0)
                    mensagemErro += "\n\tA lista de documentos está vazia ou não foi inicializada.\n";

                if (Custos == null || Custos.Count == 0)
                    mensagemErro += "\n\tA lista de custos está vazia ou não foi inicializada.\n";

                Console.WriteLine(mensagemErro);
                Console.WriteLine("\n\tPor favor, corrija a situação antes de listar as informações do caso.");

                return;
            }

            App.LimparTela();
            Console.WriteLine("\n\t======= INFORMAÇÕES DO CASO JURÍDICO =======");

            Console.WriteLine($"\tData de Abertura: {DataInicio}");
            Console.WriteLine($"\tCliente: {Cliente.Nome}");
            Console.WriteLine($"\tCPF do Cliente: {Cliente.Cpf}");
            Console.WriteLine($"\tProbabilidade de Sucesso: {ProbabilidadeSucesso * 10:#0}%");

            Console.WriteLine("\n\t======= ADVOGADOS ASSOCIADOS AO CASO =======");
            foreach (Advogado advogado in Advogados)
            {
                Console.WriteLine("\tNome: " + advogado.Nome);
                Console.WriteLine("\tCNA: " + advogado.Cna);
            }

            Console.WriteLine("\n\t============ DOCUMENTOS DO CASO ============");
            foreach (Documento documento in Documentos)
            {
                Console.WriteLine("\tData de Modificação: " + documento.DataHoraModificacao);
                Console.WriteLine("\tCódigo: " + documento.Codigo);
                Console.WriteLine("\tTipo: " + documento.Tipo);
                Console.WriteLine("\tDescrição: " + documento.Descricao);
            }

            Console.WriteLine("\n\t============== CUSTOS DO CASO =============");
            foreach ((float valor, string descricao) in Custos)
            {
                Console.WriteLine($"\tValor: {valor:F2}");
                Console.WriteLine("\tDescrição: " + descricao);
            }

            Console.WriteLine($"\tStatus: {Status}");

            if (DataEncerramento.HasValue)
            {
                Console.WriteLine($"\tData de Encerramento: {DataEncerramento}");
            }
            Console.Write("\t===========================================");

        }

        public void ListarTodosOsCasos()
        {
            
            if (casos.Count == 0)
            {
                App.LimparTela();
                Console.WriteLine("\n\tNão há casos cadastrados.");
                return;
            }

            App.LimparTela();
            Console.WriteLine("\n\t======= LISTA DE CASOS JURÍDICOS =======");

            foreach (CasoJuridico caso in casos)
            {
                Console.WriteLine("\n\t========= INFORMAÇÕES DO CASO JURÍDICO =========");
                Console.WriteLine($"\tData de Abertura: {caso.DataInicio}");
                Console.WriteLine($"\tCliente: {caso.Cliente.Nome}");
                Console.WriteLine($"\tCPF do Cliente: {caso.Cliente.Cpf}");
                Console.WriteLine($"\tProbabilidade de Sucesso: {caso.ProbabilidadeSucesso * 10:#0}%");
                Console.WriteLine("\n\t======= ADVOGADOS ASSOCIADOS AO CASO =======");
                Console.WriteLine($"\tAdvogado Principal: {caso.Advogados[0].Nome}");
                Console.WriteLine($"\tCNA do Advogado Principal: {caso.Advogados[0].Cna}");
                Console.WriteLine("\n\t============ DOCUMENTOS DO CASO ============");
                Console.WriteLine($"\tData de Modificação do Documento: {caso.Documentos[0].DataHoraModificacao}");
                Console.WriteLine($"\tCódigo do Caso: {caso.Documentos[0].Codigo}");
                Console.WriteLine($"\tTipo do Documento: {caso.Documentos[0].Tipo}");
                Console.WriteLine($"\tDescrição do Documento: {caso.Documentos[0].Descricao}");
                Console.WriteLine("\n\t============== CUSTOS DO CASO ==============");
                Console.WriteLine($"\tValor do Custo: {caso.Custos[0].Item1:F2}");
                Console.WriteLine($"\tDescrição do Custo: {caso.Custos[0].Item2}");
                Console.WriteLine($"\tStatus: {caso.Status}");
                Console.WriteLine($"\tData de Encerramento: {caso.DataEncerramento}");
                Console.WriteLine("\t============================================");
            }
        }

        public float CalcularCustoTotal()
        {
            return Custos.Sum(custo => custo.Item1);
        }
    }
}