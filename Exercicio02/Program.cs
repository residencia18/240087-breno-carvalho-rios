using Exercicio02.Classes;
using Exercicio02.Enums;

var listaMercado = new List<ItemMercado>{
    new ItemMercado(){ Nome = "Arroz", Tipo = TipoItem.Comida, Preco = 3.90 },
    new ItemMercado(){ Nome = "Azeite", Tipo = TipoItem.Comida, Preco = 2.50 },
    new ItemMercado(){ Nome = "Macarrão", Tipo = TipoItem.Comida, Preco = 3.90 },
    new ItemMercado(){ Nome = "Cerveja", Tipo = TipoItem.Bebida, Preco = 22.90 },
    new ItemMercado(){ Nome = "Refrigerante", Tipo = TipoItem.Bebida, Preco = 5.50 },
    new ItemMercado(){ Nome = "Shampoo", Tipo = TipoItem.Higiene, Preco = 7.00 },
    new ItemMercado(){ Nome = "Sabonete", Tipo = TipoItem.Higiene, Preco = 2.40 },
    new ItemMercado(){ Nome = "Cotonete", Tipo = TipoItem.Higiene, Preco = 5.70 },
    new ItemMercado(){ Nome = "Sabão em Pó", Tipo = TipoItem.Limpeza, Preco = 8.20 },
    new ItemMercado(){ Nome = "Detergente", Tipo = TipoItem.Limpeza, Preco = 2.60 },
    new ItemMercado(){ Nome = "Amaciante", Tipo = TipoItem.Limpeza, Preco = 6.40 },
};

var listaItensHigieneOrdemDePreco = listaMercado.Where(item => item.Tipo == TipoItem.Higiene).OrderBy(item => item.Preco).ToList();
var listaPrecoMenorQueCinco = listaMercado.Where(item => item.Preco < 5).OrderBy(item => item.Preco).ToList();
var listaComidaOuBebida = listaMercado.Where(item => item.Tipo == TipoItem.Comida || item.Tipo == TipoItem.Bebida).OrderBy(item => item.Nome).ToList();
var listaTiposComQuantidade = listaMercado
    .GroupBy(item => item.Tipo)
    .Select(item => new { Tipo = item.Key, Quantidade = item.Count() })
    .ToList();


imprimirLista($"Lista em Ordem Crescente de preço", listaItensHigieneOrdemDePreco);
imprimirLista($"Lista preço menor do que 5", listaPrecoMenorQueCinco);
imprimirLista($"Lista Comida ou Bebida", listaComidaOuBebida);

Console.WriteLine($"Lista de Tipos com Quantidade de Itens");
foreach (var tipo in listaTiposComQuantidade)
{
    Console.WriteLine($"{tipo.Tipo} - Quantidade: {tipo.Quantidade}");
}
Console.WriteLine();

Console.WriteLine($"Lista de Tipos com Preço Máximo, Mínimo e Média");
foreach (var tipo in listaTiposComQuantidade)
{
    var precosDoTipo = listaMercado.Where(item => item.Tipo == tipo.Tipo).Select(item => item.Preco).ToList();
    var precoMaximo = precosDoTipo.Max();
    var precoMinimo = precosDoTipo.Min();
    var precoMedia = precosDoTipo.Average();
    Console.WriteLine($"{tipo.Tipo} - Preço máximo: {precoMaximo:C} - Preço mínimo: {precoMinimo:C} - Preço médio: {precoMedia:C}");
}
Console.WriteLine();

void imprimirLista(string titulo, List<ItemMercado> lista)
{
    Console.WriteLine(titulo);
    foreach (var item in lista)
    {
        Console.WriteLine($"{item.Nome} - Preço: {item.Preco:C} - Tipo: Tipo: {Enum.GetName(typeof(TipoItem), item.Tipo)}");
    }
    Console.WriteLine();
}
