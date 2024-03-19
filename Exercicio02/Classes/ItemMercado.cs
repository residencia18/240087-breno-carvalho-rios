using Exercicio02.Enums;

namespace Exercicio02.Classes;

public class ItemMercado
{
    public required string Nome { get; set; }
    public required TipoItem Tipo { get; set; }
    public double Preco { get; set; }
}
