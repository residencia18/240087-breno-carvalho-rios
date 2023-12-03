namespace AvaliacaoDotNet
{
    public class ListaAdvogado
    {
        public List<Advogado> advogados { get; set; }

        public ListaAdvogado()
        {
            advogados = new List<Advogado>();
        }

        public void AdicionarAdvogado(Advogado advogado)
        {
            advogados.Add(advogado);
        }

        public List<Advogado> GetAdvogados()
        {
            return advogados;
        }

        public void Cadastrar()
        {
            Console.Write("\n\tDigite o nome do advogado: ");
            string nome = Console.ReadLine()!;
            nome = Pessoa.ConvertePrimeiraLetraParaMaiuscula(nome);

            string cpf;
            do
            {
                App.LimparTela();
                Console.Write("\n\tDigite o CPF do advogado: ");
                cpf = Console.ReadLine()!;

                if (!Advogado.IsValidCPF(cpf) || !Advogado.IsCpfUnico(cpf, advogados))
                {
                    App.LimparTela();
                    Console.WriteLine("\n\tOps, CPF inválido ou já existe no cadastro. Por favor, digite um CPF válido.");
                    App.Pause();
                }

            } while (!Advogado.IsValidCPF(cpf) || !Advogado.IsCpfUnico(cpf, advogados));

            DateTime dataNascimento = Advogado.ObterDataDeNascimento();

            int cna;
            do
            {
                App.LimparTela();
                cna = Advogado.ValidarEntradaCNA("\n\tDigite o CNA do advogado: ");

                if (!Advogado.IsCnaUnico(cna, advogados))
                {
                    App.LimparTela();
                    Console.WriteLine("\n\tOps, CNA já existe no cadastro. Por favor, digite um CNA válido.");
                    App.Pause();
                }

            } while (!Advogado.IsCnaUnico(cna, advogados));

            Console.Write("\n\tDigite a especialidade do advogado: ");
            string especialidades = Console.ReadLine()!;
            especialidades = Cliente.ConvertePrimeiraLetraParaMaiuscula(especialidades);

            // AdicionarAdvogado(new Advogado(nome, dataNascimento, cpf, cna, especialidades));

            // App.Pause();
            // ExibirDadosAdvogado(cpf);
            // Console.WriteLine("\n\tAdvogado cadastrado com sucesso!");
            // App.Pause();

        }

        public void Listar()
        {
            Console.WriteLine("\n\t=== Lista de Advogados ===");
            foreach (Advogado advogado in advogados)
            {
                Console.WriteLine("\tNome: " + advogado.Nome);
                Console.WriteLine("\tCPF: " + advogado.Cpf);
                Console.WriteLine("\tData de Nascimento: " + advogado.DataNascimento.ToString("dd/MM/yyyy"));
                Console.WriteLine("\tIdade: " + advogado.Idade);
                Console.WriteLine("\tCNA: " + advogado.Cna);
                Console.WriteLine("\tEspecialidade: " + advogado.Especialidade);
                Console.WriteLine("\t==========================\n");
            }
        }

        public void ExibirDadosAdvogado(String cpf)
        {
            Console.WriteLine("\n\t=== Dados do Advogado ===");
            Console.WriteLine("\tNome: " + advogados[advogados.FindIndex(cliente => cliente.Cpf == cpf)].Nome);
            Console.WriteLine("\tCPF: " + advogados[advogados.FindIndex(cliente => cliente.Cpf == cpf)].Cpf);
            Console.WriteLine("\tData de Nascimento: " + advogados[advogados.FindIndex(cliente => cliente.Cpf == cpf)].DataNascimento.ToString("dd/MM/yyyy"));
            Console.WriteLine("\tIdade: " + advogados[advogados.FindIndex(cliente => cliente.Cpf == cpf)].Idade);
            Console.WriteLine("\tEstado Civil: " + advogados[advogados.FindIndex(cliente => cliente.Cpf == cpf)].Cna);
            Console.WriteLine("\tProfissão: " + advogados[advogados.FindIndex(cliente => cliente.Cpf == cpf)].Especialidade);
            Console.Write("\t==========================");
        }

        public void Editar()
        {
            Console.WriteLine("\n\t=== Editar Advogado ===");
            Console.Write("\n\tDigite o CPF do advogado que deseja editar: ");
            string cpf = Console.ReadLine()!;

            Advogado advogado = advogados.Find(advogado => advogado.Cpf == cpf);

            if (advogado != null)
            {
                ExibirDadosAdvogado(cpf);
                App.Pause();

                Console.Write("\n\tDigite o novo nome do advogado: ");
                string nome = Console.ReadLine()!;
                nome = Cliente.ConvertePrimeiraLetraParaMaiuscula(nome);

                string cpfNovo;
                do
                {
                    Console.Write("\n\tDigite o novo CPF do advogado: ");
                    cpfNovo = Console.ReadLine()!;

                    if (!Pessoa.IsValidCPF(cpfNovo) || !Advogado.IsCpfUnico(cpfNovo, advogados))
                    {
                        Console.WriteLine("\n\tOps, CPF inválido ou já existe no cadastro. Por favor, digite um CPF válido.");
                        App.Pause();
                    }

                } while (!Pessoa.IsValidCPF(cpfNovo) || !Advogado.IsCpfUnico(cpfNovo, advogados));

                DateTime dataNascimento = Advogado.ObterDataDeNascimento();

                int cna = Advogado.ValidarEntradaCNA("\n\tDigite o novo CNA do advogado: ");

                Console.Write("\n\tDigite a nova especialidade do advogado: ");
                string especialidades = Console.ReadLine()!;

                advogado.Nome = nome;
                advogado.Cpf = cpfNovo;
                advogado.DataNascimento = dataNascimento;
                advogado.Idade = Pessoa.CalcularIdade(dataNascimento);
                advogado.Cna = cna;
                advogado.Especialidade = especialidades;

                ExibirDadosAdvogado(cpfNovo);
                Console.WriteLine("\n\tAdvogado editado com sucesso!");
                App.Pause();

            }
            else
            {
                Console.WriteLine("\n\tAdvogado não encontrado.");
                App.Pause();
            }

        }

        public void Excluir()
        {
            Console.WriteLine("\n\t=== Excluir Advogado ===");
            Console.Write("\n\tDigite o CPF do advogado que deseja excluir: ");
            string cpf = Console.ReadLine()!;

            Advogado advogado = advogados.Find(advogado => advogado.Cpf == cpf);

            if (advogado != null)
            {
                ExibirDadosAdvogado(cpf);
                App.Pause();

                Console.Write("\n\tTem certeza que deseja excluir este advogado? (S/N): ");
                string confirmacao = Console.ReadLine()!;

                if (confirmacao.ToUpper() == "S")
                {
                    advogados.Remove(advogado);
                    Console.WriteLine("\n\tAdvogado excluído com sucesso!");
                    App.Pause();
                }
                else
                {
                    Console.WriteLine("\n\tExclusão cancelada.");
                    App.Pause();
                }
            }
            else
            {
                Console.WriteLine("\n\tAdvogado não encontrado.");
                App.Pause();
            }
        }

        public void Pesquisar()
        {
            Console.WriteLine("\n\t=== Pesquisar Advogado ===");
            Console.Write("\n\tDigite o CPF do advogado que deseja pesquisar: ");
            string cpf = Console.ReadLine()!;

            Advogado advogado = advogados.Find(advogado => advogado.Cpf == cpf);

            if (advogado != null)
            {
                ExibirDadosAdvogado(cpf);
                Console.WriteLine("\n\tAdvogado encontrado com sucesso!");
                App.Pause();
            }
            else
            {
                Console.WriteLine("\n\tAdvogado não encontrado.");
                App.Pause();
            }
        }

    }
}