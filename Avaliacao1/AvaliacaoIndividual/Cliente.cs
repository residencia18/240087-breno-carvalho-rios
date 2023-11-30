namespace advocacia;
public class Cliente : Pessoa {
    private string estadoCivil;
    private string profissao;
    public string Profissao
    {
        get { return profissao; }
        set {
            if(String.IsNullOrWhiteSpace(value)){
                throw new Exceptions.EmptyInputException("A profissão não pode estar em branco.");
            }
            profissao = value;
        }
    }
    
    public string EstadoCivil
    {
        get { return estadoCivil; }
        set {
            if(String.IsNullOrWhiteSpace(value)){
                throw new Exceptions.EmptyInputException("O estado civil não pode estar em branco.");
            }
            estadoCivil = value;
        }
    }
    
    public Cliente(
        string _nome,
        string _cpf,
        DateTime _nascimento,
        string _estadoCivil,
        string _profissao
    ) : base(_nome, _cpf, _nascimento) {
        this.EstadoCivil = _estadoCivil;
        this.Profissao = _profissao;
    }

    public new string ToStr() {
        return $"CPF: {this.Cpf} | Nome: {this.Nome} | Profissão: {this.profissao} | Nascimento: {this.Nascimento} | Estado Civil: {this.estadoCivil}";
    }
}
