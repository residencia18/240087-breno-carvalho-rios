namespace advocacia;

using System.Linq;
public class App {
    List<Advogado> advogados;
    List<Cliente> clientes;

    public App() {
        advogados = new();
        clientes = new();
    }
    
    public void testApp(){
        try {
            insereAdvogado("123456789123", "Advogado 1", "12345678901", "17/07/2001");
            insereAdvogado("123456789323", "Advogado 2", "12345678902", "17/07/1980");
            insereAdvogado("123456781289", "Advogado 1", "12345678911", "17/10/2001");
            insereCliente("Cliente 1", "12345678912", "17/10/2001", "Solteiro", "Empregado");
            insereCliente("Cliente 2", "16732312411", "17/12/1990", "Casado", "Empregado");
        } catch (Exceptions.UniqueValueException ex) {
            Console.WriteLine($"{ex.Message}");            
        }

        Console.WriteLine($"Lista de Advogados");            
        listaAdvogados();
        Console.WriteLine($"-----------------");

        Console.WriteLine($"Lista de Clientes");            
        listaClientes();
        Console.WriteLine($"-----------------");
        
        Console.WriteLine($"Advogados entre idade");            
        this.advogadosEntreIdade("25", "50");
        Console.WriteLine($"-----------------");

        Console.WriteLine($"Clientes entre idade");            
        this.clientesEntreIdade("18", "25");
        Console.WriteLine($"-----------------");

        Console.WriteLine($"Clientes por Estado Civil");            
        this.clientesPorEstadoCivil("Solteiro");
        Console.WriteLine($"-----------------");
        
        Console.WriteLine($"Clientes ordem alfabetica");            
        this.clientesOrdemAlfabetica();
        Console.WriteLine($"-----------------");


        Console.WriteLine($"Profissao clientes por keyword");
        this.clientesPorKeyword("Empre");
        Console.WriteLine($"-----------------");
        
        Console.WriteLine($"Aniversariantes do mes");
        this.pessoasAniversariantesDoMes("12");
    }

    public void insereAdvogado(string cna, string nome, string cpf, string nascimento) {
        if(this.advogados.Any(x => x.Cpf == cpf) || this.clientes.Any(x => x.Cpf == cpf)){
            throw new Exceptions.UniqueValueException("CPF já está cadastrado!");
        }
        if(this.advogados.Any(x => x.Cna == cna)){
            throw new Exceptions.UniqueValueException("CNA precisa ser único!");
        }

        try {
            DateTime dataNascimento = DateTime.Parse(nascimento);
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
        if(this.advogados.Any(x => x.Cpf == cpf) || this.clientes.Any(x => x.Cpf == cpf)){
            throw new Exceptions.UniqueValueException("CPF já está cadastrado!");
        }
        try {
            DateTime dataNascimento = DateTime.Parse(nascimento);
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

    public void advogadosEntreIdade(string minIdade, string maxIdade){
        int min, max;
        try {
            min = int.Parse(minIdade);
            max = int.Parse(maxIdade);
        } catch(FormatException) {
            Console.WriteLine($"Insira valores válidos para as idades");
            return;            
        }

        foreach(Advogado advogado in this.advogados.Where(x => x.idade() > min && x.idade() < max).ToList()){
            Console.WriteLine(advogado.ToStr());
        }
    }

    public void clientesEntreIdade(string minIdade, string maxIdade){
        int min, max;
        try {
            min = int.Parse(minIdade);
            max = int.Parse(maxIdade);
        } catch(FormatException) {
            Console.WriteLine($"Insira valores válidos para as idades");
            return;            
        }

        foreach(Cliente cliente in this.clientes.Where(x => x.idade() > min && x.idade() < max).ToList()){
            Console.WriteLine(cliente.ToStr());
        }
    }

    public void clientesPorEstadoCivil(string estadoCivil){
        foreach(Cliente cliente in this.clientes.Where(x => x.EstadoCivil!.ToLower().Equals(estadoCivil.ToLower())).ToList()){
            Console.WriteLine(cliente.ToStr());
        }
    }

    public void clientesOrdemAlfabetica(){
        foreach(Cliente cliente in this.clientes.OrderBy(x => x.Nome).ToList()){
            Console.WriteLine(cliente.ToStr());
        }
    }

    public void clientesPorKeyword(string keywords){
        foreach(Cliente cliente in this.clientes.Where(x => x.Profissao!.ToLower().Contains(keywords.ToLower())).ToList()){
            Console.WriteLine(cliente.ToStr());
        }
    }

    public void pessoasAniversariantesDoMes(string inputMes){
        int mes;
        try {
            mes = int.Parse(inputMes);
        } catch(FormatException) {
            Console.WriteLine($"Insira valores válidos para as idades");
            return;            
        }

        foreach(Advogado advogado in this.advogados.Where(x => x.Nascimento.Month == mes).ToList()){
            Console.WriteLine($"{advogado.ToStr()}");
        }
        foreach(Cliente cliente in this.clientes.Where(x => x.Nascimento.Month == mes).ToList()){
            Console.WriteLine($"{cliente.ToStr()}");
        }
    }
}
