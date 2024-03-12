using Exercicio01.Classes;

Console.WriteLine($"Criando lâmpada desligada...");
Lampada lampada = new Lampada(false);
lampada.Imprimir();

Console.WriteLine($"Ligando lâmpada...");
lampada.Ligar();
lampada.Imprimir();

Console.WriteLine($"Desligando lâmpada...");
lampada.Desligar();
lampada.Imprimir();
