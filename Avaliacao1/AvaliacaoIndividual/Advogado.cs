namespace advocacia;
public class Advogado : Pessoa { 
    private string cna;
    public string Cna {
        get { return cna; }
        set { cna = value; }
    }
    
    public Advogado(string cna, string nome, string cpf, DateOnly nascimento) : base(nome, cpf, nascimento) {
        this.cna = cna;
    }
}
