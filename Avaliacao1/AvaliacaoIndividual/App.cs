namespace advocacia;
public class App {
    List<Advogado> advogados;

    public App() {
        advogados = new();
    }

    public void insereAdvogado(string cna, string nome, string cpf, DateOnly nascimento) {
        if(this.advogados.Any(x => x.Cpf == cpf && x.Cna == cna)){
            throw new Exceptions.UniqueValueException("CPF e CNA precisam ser únicos!");
        }

        try {
            Advogado advogado = new Advogado(cna, nome, cpf, nascimento);
        } catch (Exceptions.EmptyInputException ex) {
            Console.WriteLine($"{ex.Message}");            
        } catch (Exceptions.InvalidCpfException ex) {
            Console.WriteLine($"{ex.Message}");            
        } catch (Exceptions.InvalidCnaException ex) {
            Console.WriteLine($"{ex.Message}");            
        }
    }
}
