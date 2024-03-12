namespace Exercicio01.Classes;
public class Lampada
{
    private bool ligada;

    public Lampada(bool ligada){
        this.ligada = ligada;
    }

    public void Ligar(){
        this.ligada = true;
    }
    public void Desligar(){
        this.ligada = false;
    }

    public void Imprimir(){
        Console.WriteLine($"Lâmpada {(this.ligada ? "ligada" : "desligada")}");
    }
}
