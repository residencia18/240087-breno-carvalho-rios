using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;
using ResTIConnect.Domain.Entities;
using ResTIConnect.Domain.Exceptions;
using ResTIConnect.Infrastructure.Context;

namespace ResTIConnect.Application.Services;

public class EnderecoService : IEnderecoService
{
    private readonly ResTIConnectDbContext _context;

    public EnderecoService(ResTIConnectDbContext context)
    {
        _context = context;
    }

    public Endereco GetByDbId(int id)
    {
        var _endereco = _context.Enderecos.Find(id);

        if (_endereco is null)
            throw new EnderecoNotFoundException();

        return _endereco;
    }

    public List<EnderecoViewModel> GetAll()
    {
        var enderecos = _context.Enderecos
               .Select(e => new EnderecoViewModel
               {
                   EnderecoId = e.EnderecoId,
                   Logradouro = e.Logradouro,
                   Numero = e.Numero,
                   Cidade = e.Cidade,
                   Complemento = e.Complemento,
                   Bairro = e.Bairro,
                   Cep = e.Cep,
                   Estado = e.Estado,
                   Pais = e.Pais
               })
               .ToList();

        return enderecos;
    }

    public int Create(NewEnderecoInputModel endereco)
    {
        var _endereco = new Endereco
        {
            Logradouro = endereco.Logradouro,
            Numero = endereco.Numero,
            Cidade = endereco.Cidade,
            Complemento = endereco.Complemento,
            Bairro = endereco.Bairro,
            Cep = endereco.Cep,
            Estado = endereco.Estado,
            Pais = endereco.Pais
        };

        _context.Enderecos.Add(_endereco);
        _context.SaveChanges();

        return _endereco.EnderecoId;
    }

    public EnderecoViewModel? GetById(int id)
    {
        var endereco = GetByDbId(id);

        var enderecoViewModel = new EnderecoViewModel
        {
            EnderecoId = endereco.EnderecoId,
            Logradouro = endereco.Logradouro,
            Numero = endereco.Numero,
            Cidade = endereco.Cidade,
            Complemento = endereco.Complemento,
            Bairro = endereco.Bairro,
            Cep = endereco.Cep,
            Estado = endereco.Estado,
            Pais = endereco.Pais
        };
        return enderecoViewModel;
    }

    public void Update(int id, NewEnderecoInputModel endereco)
    {
        var _endereco = GetByDbId(id);
            _endereco.Logradouro = endereco.Logradouro;
            _endereco.Numero = endereco.Numero;
            _endereco.Cidade = endereco.Cidade;
            _endereco.Complemento = endereco.Complemento;
            _endereco.Bairro = endereco.Bairro;
            _endereco.Cep = endereco.Cep;
            _endereco.Estado = endereco.Estado;
            _endereco.Pais = endereco.Pais;

            _context.Enderecos.Update(_endereco);
            _context.SaveChanges();
    }

    public void Delete(int id)
    {
        _context.Enderecos.Remove(GetByDbId(id));
        _context.SaveChanges();
    }

}
