﻿using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using Cepedi.Banco.Pessoa.Dominio.Entidades;
using Cepedi.Banco.Pessoa.Dominio.Repository;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.Banco.Pessoa.Dados.Repositorios;

public class EnderecoRepository : IEnderecoRepository
{
    private readonly ApplicationDbContext _context;

    public EnderecoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<EnderecoEntity> AtualizarEnderecoAsync(EnderecoEntity endereco)
    {
        _context.Endereco.Update(endereco);
        await _context.SaveChangesAsync();

        return endereco;
    }

    public async Task<EnderecoEntity> CadastrarEnderecoAsync(EnderecoEntity endereco)
    {
        _context.Endereco.Add(endereco);
        await _context.SaveChangesAsync();

        return endereco;
    }

    public async Task<EnderecoEntity> ExcluirEnderecoAsync(EnderecoEntity endereco)
    {
        _context.Endereco.Remove(endereco);
        await _context.SaveChangesAsync();

        return endereco;
    }

    public async Task<EnderecoEntity> ObterEnderecoAsync(int id)
    {
        var endereco = await _context.Endereco.FirstOrDefaultAsync(endereco => endereco.Id == id);
        return endereco;
    }

    public async Task<EnderecoEntity> ObterEnderecoPorCepAsync(string cep)
    {
        var endereco = await _context.Endereco.FirstOrDefaultAsync(endereco => endereco.Cep == cep);
        return endereco;
    }

    public async Task<List<EnderecoEntity>> ObterTodosEnderecosAsync()
    {
        var enderecos = await _context.Endereco.ToListAsync();
        return enderecos;
    }

    public async Task<EnderecoEntity?> ConsultaCepValido(string cep)
    {
        var apiUrl = $"https://viacep.com.br/ws/{cep}/json/";
        var httpClient = new HttpClient();

        var response = await httpClient.GetAsync(apiUrl);

        if (!response.IsSuccessStatusCode)
        {
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return null;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode} - {response.ReasonPhrase}");
            }
        }

        var responseContent = await response.Content.ReadAsStringAsync();
        var responseData = JsonSerializer.Deserialize<EnderecoViaCepDto>(responseContent);

        return new EnderecoEntity()
        {
            Cep = responseData.Cep,
            Bairro = responseData.Bairro,
            Cidade = responseData.Localidade,
            Complemento = responseData.Complemento,
            Logradouro = responseData.Logradouro,
            Numero = "",
            Pais = "",
            Uf = responseData.Uf
        };
    }
}
