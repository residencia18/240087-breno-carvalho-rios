namespace AvaliacaoDotNet;

public class CasoJuridico{
    public DateTime DataInicio { get; set; }
    public float ProbabilidadeSucesso { get; set; }
    public string Status { get; set; }
    public List<(float, string)> Custos { get; set; }
    public DateTime? DataEncerramento { get; set; }
    public Cliente Cliente { get; set; }
    public List<Documento> Documentos { get; set; }

    public CasoJuridico(DateTime dt_abertura, Cliente cliente, float probabilidadeSucesso){
        Documentos = new List<Documento>();
        Custos = new List<(float, string)>();
        Status = "Em aberto";
        Cliente = cliente;
        DataInicio = dt_abertura;
        DataEncerramento = default;
        ProbabilidadeSucesso = probabilidadeSucesso;
    }

    public void AddDocumento(Documento documento){
        if(Documentos.Contains(documento))
            throw new InvalidOperationException("Já existe um documento neste caso com o código informado!");
        Documentos.Add(documento);
        App.Cx_Msg("Documento adicionado com sucesso!");
    }

    public void RemoveDocumento(int _codigo){
        if(Documentos.Count == 1)
            throw new InvalidOperationException("Ao menos um documento precisa ser anexado ao caso!");
        Documento? documento = Documentos.FirstOrDefault(d => d.Codigo == _codigo);
        if(documento == default)
            throw new InvalidOperationException("Não foi encontrado um documento com o código informado!");
        Documentos.Remove(documento);
        App.Cx_Msg("Documento removido com sucesso!");
    }

    public void AdicionarCusto(float valor, string descricao){
        Custos.Add((valor, descricao));
        App.Cx_Msg("Novo custo adicionado com sucesso!");
    }

    public void RemoverCusto(float valor, string descricao){
        if(Custos.Count == 1)
            throw new InvalidOperationException("Ao menos um custo deve ser informado!");
        var Remover = Custos.FirstOrDefault(c => c.Item1 == valor && c.Item2 == descricao);

        if (Remover == default)
            throw new InvalidOperationException("Não foi encontrado um custo com os mesmos valores na lista!");

        Custos.Remove(Remover);
        App.Cx_Msg("Custo removido com sucesso!");
    }

    public float CalcularCustoTotal(){
        return Custos.Sum(custo => custo.Item1);
    }

    public new string ToString(){
        string texto;
        if(Status == "Em aberto"){
            texto = $"Abertura do caso: {DataInicio.ToShortDateString} \n" +
                    $"Probabilidade de sucesso: {ProbabilidadeSucesso:F2} \n";
        }else
            texto = $"Encerramento do caso: {DataEncerramento.ToString} \n";
        texto += $"Custo total: {CalcularCustoTotal:F2} \n" +
                 $"Nº de documentos: {Documentos.Count} \n" +
                 $"Status: {Status}\n";
        return texto;
    }
}
