using Banco;

ContaBancaria conta = new() {
    Saldo = 100
};
Console.WriteLine($"{conta.Saldo}");

try{
    conta.Saldo = -50;
    Console.WriteLine($"{conta.Saldo}");
} catch (ArgumentException e) {
    Console.WriteLine($"{e.Message}");    
}