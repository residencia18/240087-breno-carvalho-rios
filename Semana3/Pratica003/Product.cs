namespace Pratica003;

public class Product {
    public string Cod { get; set; }
    public string Name { get; set; }
    public int Stock { get; private set; }

    public int UnitsInItem { get; set; }
    public float Price { get; set; }

    public Product(string cod, string name, float price, int stock) {
        this.Cod = cod;
        this.Name = name;
        this.Price = price;
        this.Stock = stock;
    }

    public void addStock(int entry){
        if(entry < 0) {
            throw new Exceptions.NegativeStockChange("Movimentação de Negativa de Estoque!");
        }
        this.Stock += entry;
    }

    public void subStock(int exit){
        if(exit < 0) {
            throw new Exceptions.NegativeStockChange("Movimentação de Negativa de Estoque!");
        }
        if(this.Stock < exit) {
            throw new Exceptions.InsufficientStock("Estoque insuficiente!");
        }
        this.Stock -= exit;
    }

    public float totalPrice(){
        return this.Price * this.Stock;
    }

    public float totalStock(){
        return this.UnitsInItem * this.Stock;
    }

    public override string ToString(){
        return $"Código: {this.Cod} | Nome: {this.Name} | Preço: {this.Price.ToString("c2")} | Qtd. em Estoque: {this.Stock}";
    }
}
