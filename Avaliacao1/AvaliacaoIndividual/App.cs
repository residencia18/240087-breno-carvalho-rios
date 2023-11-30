namespace advocacia;
public class App {
    List<Advogado> advogados;
    List<Cliente> clientes;

    public App() {
        advogados = new();
        clientes = new();

        try {
            insereAdvogado("123456789123", "Advogado 1", "12345678901", "17/07/2001");
            insereAdvogado("123456789323", "Advogado 2", "12345678902", "17/07/2001");
            insereAdvogado("123456789123", "Advogado 1", "12345678911", "17/25/2001");
        } catch (Exceptions.UniqueValueException ex) {
            Console.WriteLine($"{ex.Message}");
            
        }
    }

    public void insereAdvogado(string cna, string nome, string cpf, string nascimento) {
        if(this.advogados.Any(x => x.Cpf == cpf && x.Cna == cna)){
            throw new Exceptions.UniqueValueException("CPF e CNA precisam ser únicos!");
        }

        try {
            DateOnly dataNascimento = DateOnly.Parse(nascimento);
            Advogado advogado = new Advogado(cna, nome, cpf, dataNascimento);
            this.advogados.Add(advogado);
        } catch (Exceptions.EmptyInputException ex) {
            Console.WriteLine($"{ex.Message}");            
        } catch (Exceptions.InvalidCpfException ex) {
            Console.WriteLine($"{ex.Message}");            
        } catch (Exceptions.InvalidCnaException ex) {
            Console.WriteLine($"{ex.Message}");            
        } catch (Exceptions.InvalidDateException ex) {
            Console.WriteLine($"{ex.Message}");            
        } catch (Exception ex) {
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");            
        }
    }

    public void insereCliente(string nome, string cpf, string nascimento, string estadoCivil, string profissao) {
        if(this.clientes.Any(x => x.Cpf == cpf)){
            throw new Exceptions.UniqueValueException("CPF precisa ser único!");
        }

        try {
            DateOnly dataNascimento = DateOnly.Parse(nascimento);
            Cliente cliente = new Cliente(nome, cpf, dataNascimento, estadoCivil, profissao);
            this.clientes.Add(cliente);
        } catch (Exceptions.EmptyInputException ex) {
            Console.WriteLine($"{ex.Message}");            
        } catch (Exceptions.InvalidCpfException ex) {
            Console.WriteLine($"{ex.Message}");            
        } catch (Exceptions.InvalidDateException ex) {
            Console.WriteLine($"{ex.Message}");            
        } catch (Exception ex) {
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");            
        }
    }

    public void listaAdvogados(){
        foreach(Advogado advogado in this.advogados){
            Console.WriteLine($"{advogado.Nome}");            
        }
    }

    public void listaClientes(){
        foreach(Cliente cliente in this.clientes){
            Console.WriteLine($"{cliente.Nome}");            
        }
    }
}
