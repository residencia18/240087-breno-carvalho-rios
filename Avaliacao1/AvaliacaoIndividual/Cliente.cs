namespace advocacia;
public class Cliente : Pessoa {
    private string estadoCivil;
    private string profissao;
    public string Profissao
    {
        get { return profissao; }
        set { profissao = value; }
    }
    
    public string EstadoCivil
    {
        get { return estadoCivil; }
        set { estadoCivil = value; }
    }
    
    public Cliente(
        string _nome,
        string _cpf,
        DateOnly _nascimento,
        string _estadoCivil,
        string _profissao
    ) : base(_nome, _cpf, _nascimento) {
        this.EstadoCivil = _estadoCivil;
        this.Profissao = _profissao;
    }
}
