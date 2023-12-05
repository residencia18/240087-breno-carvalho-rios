namespace AvaliacaoDotNet;
public class Advogado : Pessoa{
    public string Cna { get; set; }
    public string? Especialidade { get; set; }

    public Advogado(string nome, DateTime dataNascimento, string cpf, string cna, string especialidade)
        : base(nome, dataNascimento, cpf, idade: 0){
        Cna = cna;
        Especialidade = especialidade;
        // Calcular a idade ao criar o objeto
        Idade = CalcularIdade(dataNascimento);
    }

    public override string ToString() {
        return
            $"\tNome: {this.Nome}"
            + $"\n\tCPF: {this.Cpf}"
            + $"\n\tData de Nascimento: {this.DataNascimento.ToString("dd/MM/yyyy")}"
            + $"\n\tIdade: {this.Idade}"
            + $"\n\tCNA: {this.Cna}"
            + $"\n\tEspecialidade: {this.Especialidade}";
    }
}
