namespace AvaliacaoDotNet;

public class RelacaoCasoAdvogado{
    public static List<RelacaoCasoAdvogado> listaCasoAdvogados = new();

    public CasoJuridico Caso {get; set;}
    public Advogado Advogado {get; set;}

    public RelacaoCasoAdvogado(CasoJuridico caso, Advogado advogado){
        Caso = caso;
        Advogado = advogado;
        listaCasoAdvogados.Add(this);
    }

}
