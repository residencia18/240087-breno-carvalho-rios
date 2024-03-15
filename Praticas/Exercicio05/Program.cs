
using Exercicio05.Structs;

Triangulo<int> trianguloInteiro = new Triangulo<int>
{
    P1 = new Ponto<int> { X = 1, Y = 1, Z = 0 },
    P2 = new Ponto<int> { X = 5, Y = 4, Z = 0 },
    P3 = new Ponto<int> { X = 3, Y = 7, Z = 0 }
};
Console.WriteLine($"Triângulo de inteiros:");
Console.WriteLine($"P1 [{trianguloInteiro.P1.X} {trianguloInteiro.P1.Y} {trianguloInteiro.P1.Z}]");
Console.WriteLine($"P2 [{trianguloInteiro.P2.X} {trianguloInteiro.P2.Y} {trianguloInteiro.P2.Z}]");
Console.WriteLine($"P3 [{trianguloInteiro.P3.X} {trianguloInteiro.P3.Y} {trianguloInteiro.P3.Z}]");


Triangulo<double> trianguloDouble = new Triangulo<double>
{
    P1 = new Ponto<double> { X = 1.5, Y = 1.5, Z = 0.0 },
    P2 = new Ponto<double> { X = 5.5, Y = 4.5, Z = 0.0 },
    P3 = new Ponto<double> { X = 3.5, Y = 7.5, Z = 0.0 }
};
Console.WriteLine($"Triângulo de doubles:");
Console.WriteLine($"P1 [{trianguloDouble.P1.X} {trianguloDouble.P1.Y} {trianguloDouble.P1.Z}]");
Console.WriteLine($"P2 [{trianguloDouble.P2.X} {trianguloDouble.P2.Y} {trianguloDouble.P2.Z}]");
Console.WriteLine($"P3 [{trianguloDouble.P3.X} {trianguloDouble.P3.Y} {trianguloDouble.P3.Z}]");

Triangulo<string> trianguloString = new Triangulo<string>
{
    P1 = new Ponto<string> { X = "A", Y = "B", Z = "C" },
    P2 = new Ponto<string> { X = "D", Y = "E", Z = "F" },
    P3 = new Ponto<string> { X = "G", Y = "H", Z = "I" }
};
Console.WriteLine($"Triângulo de strings:");
Console.WriteLine($"P1 [{trianguloString.P1.X} {trianguloString.P1.Y} {trianguloString.P1.Z}]");
Console.WriteLine($"P2 [{trianguloString.P2.X} {trianguloString.P2.Y} {trianguloString.P2.Z}]");
Console.WriteLine($"P3 [{trianguloString.P3.X} {trianguloString.P3.Y} {trianguloString.P3.Z}]");
