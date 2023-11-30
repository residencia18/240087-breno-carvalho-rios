namespace Veiculos;
public class Veiculo {
    public string Modelo { get; set; }
    public string Cor { get; set; }
    public int Ano { get; set; }
    public int idadeVeiculo { 
        get {
            return DateTime.Now.Year - this.Ano;
        }
    }

    public Veiculo(string modelo, string cor, int ano) {
        this.Modelo = modelo;
        this.Cor = cor;
        this.Ano = ano;
    }
}
