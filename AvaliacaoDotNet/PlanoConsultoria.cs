namespace AvaliacaoDotNet;
public class PlanoConsultoria{
    private string _titulo { get; set; }
    private double _valor {get; set;}
    private List<string> _beneficios {get;}

    public PlanoConsultoria(string titulo, double valor){
        this._titulo = titulo;
        this._valor = valor;
        this._beneficios = new List<string>();
    }

    public string Titulo {
        get { return _titulo;}
        set { _titulo = value;}
    }

    public double Valor {
        get { return _valor;}
        set { _valor = value;}
    }

    public List<string> Beneficios {
        get { return _beneficios; }
    }

    public void NovoBeneficio(string beneficio){
        this.Beneficios.Add(beneficio);
    }

    public void RetirarBeneficio(string beneficio){
        if(this.Beneficios.Contains(beneficio)){
            this.Beneficios.Remove(beneficio);
            App.Cx_Msg("O benefício foi removido do plano!");
            return;
        }
        App.Cx_Msg("O benefício não é fornecido neste plano!");
        return;
    }

    public override string ToString(){
        return $"Plano: {Titulo}, valor R${Valor:C2}";
    }
}
