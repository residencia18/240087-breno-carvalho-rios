namespace advocacia;
public class Pessoa {
    private string nome;
    private string cpf;
    private DateOnly nascimento;

    public Pessoa(string _nome, string _cpf, DateOnly _nascimento) {
        this.Nome = _nome;
        this.Cpf = _cpf;
        this.Nascimento = _nascimento;
    }
    public string Cpf {
        get { return cpf; }
        set {
            if(cpf.Length != 11) {
                throw new Exceptions.InvalidCpfException("CPF inválido: Precisa ter 11 dígitos.")
            }
            cpf = value;
        }
    }
    
    public DateOnly Nascimento {
        get { return nascimento; }
        set {
            if(cpf.Length != 11) {
                throw new Exceptions.InvalidDateException("Data Inválida");
            }
            nascimento = value;
        }
    }
    
    public string Nome {
        get { return nome; }
        set {
            nome = value;
        }
    }
    
}
