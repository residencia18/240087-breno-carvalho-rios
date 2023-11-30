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
            cpf = value;
        }
    }
    
    public DateOnly Nascimento {
        get { return nascimento; }
        set {
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
