﻿using Cepedi.Banco.Pessoa.Compartilhado.Requests;
using Cepedi.Banco.Pessoa.Compartilhado.Responses;
using Cepedi.Banco.Pessoa.Dominio.Entidades;
using Cepedi.Banco.Pessoa.Dominio.Handlers;
using Cepedi.Banco.Pessoa.Dominio.Repository;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using NSubstitute;
using OperationResult;

namespace Cepedi.Banco.Pessoa.Domain.Tests;

public class CadastrarEnderecoRequestHandlerTests
{
    private readonly IEnderecoRepository _enderecoRepository = Substitute.For<IEnderecoRepository>();
    private readonly ILogger<CadastrarEnderecoRequestHandler> _logger = Substitute.For<ILogger<CadastrarEnderecoRequestHandler>>();
    private readonly CadastrarEnderecoRequestHandler _sut;

    public CadastrarEnderecoRequestHandlerTests()
    {
        _sut = new CadastrarEnderecoRequestHandler(_enderecoRepository, _logger);
    }

    [Fact]
    public async Task CadastrarEnderecoAsync_QuandoCadastrar_DeveRetornarSucesso()
    {
        //Arrange 
        var request = new CadastrarEnderecoRequest
        {
            Cep = "12345678",
            Logradouro = "Logradouro",
            Complemento = "Complemento",
            Bairro = "Bairro",
            Cidade = "Cidade",
            Uf = "UF",
            Pais = "Pais",
            Numero = "123",
            IdPessoa = 1
        };

        _enderecoRepository.CadastrarEnderecoAsync(It.IsAny<EnderecoEntity>()).ReturnsForAnyArgs(new EnderecoEntity());

        //Act
        var result = await _sut.Handle(request, CancellationToken.None);

        //Assert 
        result.Should().BeOfType<Result<CadastrarEnderecoResponse>>().Which.Value.Cep.Should().Be(request.Cep);
        result.Should().BeOfType<Result<CadastrarEnderecoResponse>>().Which.Value.Cep.Should().NotBeEmpty();
    }

}
