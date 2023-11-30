namespace advocacia;
public class App {
    List<Advogado> advogados;

    public App() {
        advogados = new();
    }

    public void insereAdvogado(string cna, string nome, string cpf, DateOnly nascimento) {
        if(this.advogados.Any(x => x.Cpf == cpf)){
            throw new Exceptions.UniqueCpfException("CPF precisa ser único!");
        }
        if(this.advogados.Any(x => x.Cna == cna)){
            throw new Exceptions.UniqueCpfException("CNA precisa ser único!");
        }
        Advogado advogado = new Advogado(cna, nome, cpf, nascimento);
    }
}
