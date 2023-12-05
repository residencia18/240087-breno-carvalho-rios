using System.Globalization;

namespace AvaliacaoDotNet;

public abstract class Pessoa{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public DateTime DataNascimento { get; set; }
    public int Idade { get; set; }

    public Pessoa(string nome, DateTime dataNascimento, string cpf, int idade){
        this.Nome = nome;
        this.DataNascimento = dataNascimento;
        this.Cpf = cpf;
        this.Idade = idade;
    }

    public static bool IsValidCPF(string cpf){
        // Remover caracteres não numéricos
        string numbersOnly = new string(cpf.Where(char.IsDigit).ToArray());

        // Verificar se o CPF possui 11 dígitos
        if (numbersOnly.Length != 11)
            return false;

        // Calcular os dígitos verificadores
        int[] cpfDigits = numbersOnly.Select(c => int.Parse(c.ToString())).ToArray();
        int sum = 0;

        // Calcular o primeiro dígito verificador 
        for (int i = 0; i < 9; i++)
            sum += cpfDigits[i] * (10 - i);

        // Verifica se o primeiro dígito verificador é igual ao dígito informado no CPF
        int firstDigit = 11 - (sum % 11);
        if (firstDigit > 9)
            firstDigit = 0;
        if (cpfDigits[9] != firstDigit)
            return false;

        // Calcular o segundo dígito verificador
        sum = 0;
        for (int i = 0; i < 10; i++)
            sum += cpfDigits[i] * (11 - i);

        // Verifica se o segundo dígito verificador é igual ao dígito informado no CPF
        int secondDigit = 11 - (sum % 11);
        if (secondDigit > 9)
            secondDigit = 0;
        if (cpfDigits[10] != secondDigit)
            return false;

        return true;
    }

    public static string ConvertePrimeiraLetraParaMaiuscula(string palavra, int maxTentativas = 3){
        int tentativas = 0;

        while (tentativas < maxTentativas){
            try{
                if (string.IsNullOrWhiteSpace(palavra))
                    throw new ArgumentException("A palavra não pode ser vazia ou conter apenas espaços em branco.");

                if (!palavra.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                    throw new ArgumentException("A palavra deve conter apenas letras ou espaços.");

                return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(palavra);
            }
            catch (ArgumentException ex){
                Console.WriteLine($"\n\tErro: {ex.Message}");
                Console.WriteLine("\n\tPor favor, digite novamente.");
                palavra = Console.ReadLine()!;
            }

            tentativas++;
        }

        throw new InvalidOperationException("Número máximo de tentativas atingido. O método foi interrompido.");
    }

    public static int CalcularIdade(DateTime dataNascimento){
        int idade = DateTime.Now.Year - dataNascimento.Year;

        // Verificar se o aniversário já ocorreu neste ano
        if (DateTime.Now.Month < dataNascimento.Month || (DateTime.Now.Month == dataNascimento.Month && DateTime.Now.Day < dataNascimento.Day))
            idade--;

        return idade;
    }

    public static bool TentarObterDataValida(string input, out DateTime data){
        if (DateTime.TryParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out data)
            && data.Date <= DateTime.Now.Date)
            return true;

        // Se a conversão falhar ou a data for no futuro, retorne false
        Console.WriteLine("\n\tFormato de data inválido ou data no futuro. Digite novamente.");
        return false;
    }

}
