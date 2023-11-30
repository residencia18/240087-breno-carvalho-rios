using Veiculos;

Veiculo veiculo = new("Modelo 1", "Cor 1", 2023);
Console.WriteLine($"{veiculo.Modelo} - {veiculo.Cor} - {veiculo.Ano} - {veiculo.idadeVeiculo} ano(s)");
veiculo.Modelo = "Novo modelo";
veiculo.Cor = "Nova cor";
veiculo.Ano = 2022;
Console.WriteLine($"{veiculo.Modelo} - {veiculo.Cor} - {veiculo.Ano} - {veiculo.idadeVeiculo} ano(s)");