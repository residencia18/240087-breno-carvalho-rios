# Atividade Prática 003

# 1. O que é uma exceção em Java e qual é o propósito de usá-las em programas?

Uma exceção é um evento que ocorre durante a execução de um programa que interrompe o fluxo normal de instruções. Em vez de continuar a execução como de costume, o programa transfere o controle para um bloco de código especial chamado bloco de tratamento de exceção. Essa transferência de controle é conhecida como "lançar uma exceção".

O propósito de usar exceções em programas Java é lidar com situações excepcionais ou erros que podem ocorrer durante a execução do programa sem que o mesmo seja interrompido. As exceções são usadas para sinalizar condições anormais e fornecer um mecanismo para lidar com essas condições de maneira estruturada.

# 2. Pesquise sobre a diferença entre exceções verificadas e não verificadas em Java. Dê exemplos de cada uma.

### Exceções verificadas (checked exceptions)

São aquelas que o compilador exige que o programador lide explicitamente, através de um `try-catch`, por exemplo. Essas exceções são geralmente associadas a condições que o programador pode prever e que estão fora do controle direto do programa.

Exemplos de exceções verificadas incluem `IOException`, `SQLException` e `ClassNotFoundException`.

Um exemplo de exceção ao ler um aquivo em JAVA:

Nesse caso o método FileReader pode lançar uma IOException se o arquivo "arquivo.txt" não puder ser encontrado ou se ocorrerem problemas durante a leitura.

``` Java
import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;

public class ExemploExcecaoVerificada {
    public static void main(String[] args) {
        try {
            // Código que pode gerar uma IOException
            BufferedReader reader = new BufferedReader(new FileReader("arquivo.txt"));
            String linha = reader.readLine();
            System.out.println("Conteúdo do arquivo: " + linha);
            reader.close();
        } catch (IOException e) {
            // Tratamento de exceção
            System.out.println("Erro de I/O: " + e.getMessage());
        }
    }
}
```

### Exceções não verificadas (unchecked exceptions)

São aquelas que o compilador não exige que o programador trate explicitamente. Normalmente, são associadas a erros de programação, como divisão por zero, acesso a índices inválidos em arrays e chamadas de métodos em referências nulas.

Exemplos de exceções não verificadas podem ser `ArithmeticException`, `ArrayIndexOutOfBoundsException` e `NullPointerException`.

Um exemplo de exceção ao fazer uma divisão por zero em Java:

Neste exemplo, a divisão por zero no método dividir resultará em uma ArithmeticException. Essa exceção não é verificada pelo compilador, mas ainda é uma condição de erro que deve ser tratada.

``` Java
public class ExemploExcecaoNaoVerificada {
    public static void main(String[] args) {
        try {
            // Divisão por 0
            int resultado = dividir(10, 0);
            System.out.println("Resultado: " + resultado);
        } catch (ArithmeticException e) {
            // Tratamento da exceção
            System.out.println("Erro: Divisão por zero.");
        }
    }

    // Método que pode lançar uma exceção
    public static int dividir(int numerador, int denominador) {
        return numerador / denominador;
    }
}
```

# 3. Como você pode lidar com exceções em Java? Quais são as palavras-chave e as práticas comuns para tratamento de exceções?

O tratamento de exceções é realizado usando blocos try, catch e finally:

### try

Usado para envolver o código que pode gerar uma exceção. O código dentro do bloco try é monitorado quanto a ocorrência de exceções.

``` Java
try {
    // Código aqui
}
```

### catch

Usado para capturar e lidar com exceções específicas que podem ser lançadas dentro do bloco try. É possível ter vários blocos catch para diferentes tipos de exceções.

``` Java
try {
    // Código aqui
} catch(TipoDeExcecao exception) {
    // Tratamento aqui
}
```

### finally

Usado para conter código que deve ser executado independentemente de ocorrer ou não uma exceção dentro do bloco try. O finally, ao contrário do `try` e `catch` juntos, é opcional.

``` Java
try {
    // Código aqui
} catch(TipoDeExcecao exception) {
    // Tratamento aqui
} finally {
    // Executar independentemente
}
```

Temos também como lançar exceções utilizando o `throw` e `throws`:

### throw

Usada para explicitamente lançar uma exceção. Pode ser usada dentro de um método para sinalizar uma condição de erro específica.

``` Java
throw new TipoDeExcecao("Mensagem de erro");
```

### throws

Usada na declaração de um método para indicar que o método pode lançar exceções de um determinado tipo.

``` Java
public void meuMetodo() throws TipoDeExcecao {
    // Código que pode lançar TipoDeExcecao
}
``` 

# 4. O que é o bloco "try-catch" em Java? Como ele funciona e por que é importante usá-lo ao lidar com exceções?

O bloco try-catch em Java é uma estrutura utilizada para lidar com exceções, permitindo lançar exceções dentro de um bloco try e em seguida lidar com elas usando um ou mais blocos catch.

Estrutura do "try-catch":

``` Java
try {
    // Código que pode gerar uma exceção. O código dentro do bloco try é monitorado quanto a ocorrência de exceções.
} catch(TipoDeExcecao exception) {
    // Captura e lida com exceções específicas que podem ser lançadas dentro do bloco try. É possível ter vários blocos catch para diferentes tipos de exceções.
} finally {
    // Código que será executado independentemente de ocorrer ou não uma exceção dentro do bloco try.
    // Esse bloco é opcional na estrutura do try-catch
}
```

# 5. Quando é apropriado criar suas próprias exceções personalizadas em Java e como você pode fazer isso? Dê um exemplo de quando e por que você criaria uma exceção personalizada.

Criar exceções personalizadas em Java é apropriado em situações em que desejamos representar condições específicas de erro ou situações excepcionais que não são adequadamente cobertas pelas exceções padrão fornecidas pelo Java. Ao criar exceções personalizadas, é possível fornecer informações mais específicas sobre o motivo da exceção e adicionar métodos ou campos adicionais que podem ser úteis para quem está lidando com elas.

Podemos usar um `throw` para lançar exceções com uma mensagem personalizada, por exemplo:

``` Java
// Criamos uma exceção personalizada
class SaldoInsuficienteException extends Exception {
    private double saldoAtual;

    // Construtor que recebe o saldo atual como parâmetro
    public SaldoInsuficienteException(double saldoAtual) {
        this.saldoAtual = saldoAtual;
    }

    // Método para obter o saldo atual
    public double getSaldoAtual() {
        return saldoAtual;
    }
}

class ContaBancaria {
    private double saldo;
    // Lançamos uma exceção personalizada se o saldo for insuficiente

    public void sacar(double valor) throws SaldoInsuficienteException {
        if (valor > saldo) {
            throw new SaldoInsuficienteException(saldo);
        } else {
            saldo -= valor;
            System.out.println("Saque realizado com sucesso. Novo saldo: " + saldo);
        }
    }
}
```