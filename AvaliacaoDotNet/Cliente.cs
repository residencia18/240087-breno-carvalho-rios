namespace AvaliacaoDotNet;
public class Cliente : Pessoa{
    public string EstadoCivil { get; set; }
    public string Profissao { get; set; }

    public Cliente(string nome, string cpf, DateTime dataNascimento, string estadoCivil = "Não informado", string profissao = "Não informado")
    : base(nome, dataNascimento, cpf, idade: 0){
        this.EstadoCivil = estadoCivil;
        this.Profissao = profissao;
        // Calcular a idade ao criar o objeto
        this.Idade = Pessoa.CalcularIdade(this.DataNascimento);
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
}