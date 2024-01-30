using OrdemDeServico.Domain.Entities;
using ResTIConnect.Infrastructure;

var dbContext = new OrdemDeServicoContext();

Console.WriteLine($"Criando OS");
Endereco endereco_1 = new Endereco
{
    Logradouro = "Avenida Paulista",
    Bairro = "Bela Vista",
    Cep = "00000-000",
    Cidade = "São Paulo",
    Estado = "SP",
    Numero = "100",
    Pais = "Brasil",
    Complemento = "Casa"
};

Endereco endereco_2 = new Endereco
{
    Logradouro = "Rua 1",
    Bairro = "Conquista",
    Cep = "00000-000",
    Cidade = "Ilheus",
    Estado = "BA",
    Numero = "100",
    Pais = "Brasil",
    Complemento = "Apartamento"
};

Endereco endereco_3 = new Endereco
{
    Logradouro = "Rua 2",
    Bairro = "Centro",
    Cep = "00000-000",
    Cidade = "Ilheus",
    Estado = "BA",
    Numero = "25",
    Pais = "Brasil",
    Complemento = ""
};

Cliente cliente = new Cliente
{
    Email = "1@1.com",
    Endereco = endereco_1,
    Nome = "Fulano",
    Telefone = "0000-0000"
};

PrestadorDeServico prestadorDeServico = new PrestadorDeServico
{
    Endereco = endereco_2,
    Especialidade = "Manutenção",
    Nome = "Ciclano",
    Telefone = "0000-0000"
};

Servico servico = new Servico
{
    Nome = "Manutenção",
    Precos = 100,
    Descricao = "Manutenção de Computadores",
};

OrdemServico? ordemDeServico = new OrdemServico
{
    DataDeEmissao = DateTime.Now,
    Numero = 1,
    Status = "Aberta",
    Cliente = cliente,
    PrestadorDeServico = prestadorDeServico,
    Pagamentos = new List<Pagamento>()
};

Pagamento pagamento_1 = new Pagamento
{
    DataPagamento = DateTime.Now,
    MetodoPagamento = "Cartão",
    Valor = 100,
};

Pagamento pagamento_2 = new Pagamento
{
    DataPagamento = DateTime.Now,
    MetodoPagamento = "Dinheiro",
    Valor = 32,
};

ordemDeServico.Pagamentos.Add(pagamento_1);
ordemDeServico.Pagamentos.Add(pagamento_2);

ServicoOrdemDeServico servicoOrdemDeServico = new ServicoOrdemDeServico
{
    Endereco = endereco_3,
    OrdemServico = ordemDeServico,
    Servico = servico
};

dbContext.AddRange(cliente, prestadorDeServico, servico, ordemDeServico, pagamento_1, pagamento_2, servicoOrdemDeServico);
dbContext.SaveChanges();

ordemDeServico = dbContext.OrdemServico.FirstOrDefault();

ordemDeServico.Descricao = "Servico para Empresa de T.I.";

Console.WriteLine($"Data de Emissão: {ordemDeServico.DataDeEmissao}");
Console.WriteLine($"Número: {ordemDeServico.Numero}");
Console.WriteLine($"Status: {ordemDeServico.Status}");
Console.WriteLine($"Descrição: {ordemDeServico.Descricao}");
Console.WriteLine($"Cliente: {ordemDeServico.Cliente.Nome}");
Console.WriteLine($"Prestador de Serviço: {ordemDeServico.PrestadorDeServico.Nome}");

foreach (var pagamento in ordemDeServico.Pagamentos)
{
    Console.WriteLine($"Data do Pagamento: {pagamento.DataPagamento}");
    Console.WriteLine($"Método de Pagamento: {pagamento.MetodoPagamento}");
    Console.WriteLine($"Valor: {pagamento.Valor}");
}

Console.WriteLine($"Endereço do Serviço: {servicoOrdemDeServico.Endereco.Logradouro}, {servicoOrdemDeServico.Endereco.Numero}");
Console.WriteLine($"Ordem de Serviço: {servicoOrdemDeServico.OrdemServico.Numero}");
Console.WriteLine($"Serviço: {servicoOrdemDeServico.Servico.Nome}");


Console.WriteLine();
Console.WriteLine($"Excluindo Ordem de Serviço {ordemDeServico.OrdemServicoId}");

dbContext.Remove(ordemDeServico);
dbContext.SaveChanges();

ordemDeServico = dbContext.OrdemServico.FirstOrDefault();
if (ordemDeServico is null)
{
    Console.WriteLine($"Nenhuma OS encontrada");
}
