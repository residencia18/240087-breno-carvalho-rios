namespace OrdemDeServico.WebAPI.InputModels;
public class NewPagamentoInputModel
{
    public required double Valor { get; set; }
    public required DateTime Data_pagamento { get; set; }
    public required string Metodo_pagamento { get; set; }
    public required int OrdemServicoId { get; set; }
}
