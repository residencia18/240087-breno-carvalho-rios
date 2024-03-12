using System.Text;

namespace Exercicio02.Classes;
public class Data
{
    public static readonly string FORMATO_12H = "12h";
    public static readonly string FORMATO_24H = "24h";
    private bool fullDateTime = false;
    private int dia;
    private int mes;
    private int ano;
    private int hora;
    private int minuto;
    private int segundo;
    public Data(int dia, int mes, int ano)
    {
        this.dia = dia;
        this.mes = mes;
        this.ano = ano;
    }
    public Data(int dia, int mes, int ano, int hora, int minuto, int segundo) : this(dia, mes, ano)
    {
        if (hora >= 0 || hora <= 23)
        {
            this.hora = hora;
        }
        if (minuto >= 0 || minuto <= 59){
            this.minuto = minuto;
        }
        if (segundo >= 0 || segundo <= 59){
            this.segundo = segundo;
        }
        
        this.fullDateTime = true;
    }

    public void Imprimir(string formato)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"{dia}/{mes}/{ano}");

        if (fullDateTime)
        {
            if (formato.Equals(FORMATO_24H))
            {
                sb.Append($" {hora}:{minuto}:{segundo}");
            }

            if (formato.Equals(FORMATO_12H))
            {
                sb.Append($" {(hora > 12 ? hora - 12 : hora)}:{minuto}:{segundo} {(hora > 12 ? "PM" : "AM")}");
            }
        }

        Console.WriteLine(sb.ToString());
    }
}
