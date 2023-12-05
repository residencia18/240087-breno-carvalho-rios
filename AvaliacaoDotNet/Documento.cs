namespace AvaliacaoDotNet;

public class Documento{
    public DateTime DataHoraModificacao { get; set; }
    public int Codigo { get; set; }
    public string Tipo { get; set; }
    public string Descricao { get; set; }

    // Constructor que inicializa las propiedades Tipo y Descricao
    public Documento(DateTime _dt_modificacao, int _codigo, string _tipo, string _desc){
        DataHoraModificacao = _dt_modificacao;
        Codigo = _codigo;
        Tipo = _tipo;
        Descricao = _desc;
    }
}
