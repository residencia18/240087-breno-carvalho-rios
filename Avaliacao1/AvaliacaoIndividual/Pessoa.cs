namespace advocacia;
public class Pessoa {
    private string nome;
    private string cpf;
    private DateOnly nascimento;

    public Pessoa(string nome, string cpf, DateOnly nascimento) {
        this.Nome = nome;
        this.Cpf = cpf;
        this.Nascimento = nascimento;
    }
    public string Cpf
    {
        get { return cpf; }
        set { cpf = value; }
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
