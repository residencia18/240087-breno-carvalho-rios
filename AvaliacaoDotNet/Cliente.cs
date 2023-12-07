namespace AvaliacaoDotNet;
public class Cliente : Pessoa{
    public string EstadoCivil { get; set; }
    public string Profissao { get; set; }
    public PlanoConsultoria Plano { get; set; }

    public List<IPagamento> pagamentos { get; }

    public Cliente(string nome, string cpf, DateTime dataNascimento, string estadoCivil = "Não informado", string profissao = "Não informado")
    : base(nome, dataNascimento, cpf, idade: 0){
        this.EstadoCivil = estadoCivil;
        this.Profissao = profissao;
        // Calcular a idade ao criar o objeto
        this.Idade = Pessoa.CalcularIdade(this.DataNascimento);
        this.pagamentos = new();
    }

    public static bool estadoCivil(String estadoCivil){
        return estadoCivil == "Solteiro" || estadoCivil == "Casado" || estadoCivil == "Divorciado" || estadoCivil == "Viúvo";
    }

    public override string ToString(){
        return
            $"\n\tCPF: {this.Cpf}"
            + $"\n\tNome: {this.Nome}"
            + $"\n\tData de Nascimento: {this.DataNascimento.ToString("dd/MM/yyyy")}"
            + $"\n\tIdade: {this.Idade}"
            + $"\n\tEstado Civil: {this.EstadoCivil}"
            + $"\n\tProfissão: {this.Profissao}";
    }

    public void NovoPagamento(IPagamento pagamento){
        Console.WriteLine($"{Nome} está efetuando um pagamento");
        pagamento.RealizarPagamento(pagamento.ValorBruto-pagamento.Desconto);
        pagamentos.Add(pagamento);
    }

    public void ExibirPagamentos(){
        App.LimparTela();
        Console.WriteLine("====== TODOS OS PAGAMENTOS ======");
        foreach (var item in pagamentos)
        {
            Console.WriteLine(item.ToString());
        }
        App.Pause();
    }
}