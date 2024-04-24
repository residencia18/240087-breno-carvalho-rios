using System.Text.Json.Serialization;

public class EnderecoViaCepDto
{
    [JsonPropertyName("cep")]
    public string Cep { get; set; } = default!;
    [JsonPropertyName("logradouro")]
    public string Logradouro { get; set; } = default!;
    [JsonPropertyName("complemento")]
    public string Complemento { get; set; } = default!;
    [JsonPropertyName("bairro")]
    public string Bairro { get; set; } = default!;
    [JsonPropertyName("localidade")]
    public string Localidade { get; set; } = default!;
    [JsonPropertyName("uf")]
    public string Uf { get; set; } = default!;
    [JsonPropertyName("ibge")]
    public string Ibge { get; set; } = default!;
    [JsonPropertyName("gia")]
    public string Gia { get; set; } = default!;
    [JsonPropertyName("ddd")]
    public string Ddd { get; set; } = default!;
    [JsonPropertyName("siafi")]
    public string Siafi { get; set; } = default!;
}
