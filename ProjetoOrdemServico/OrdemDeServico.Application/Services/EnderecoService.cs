using OrdemDeServico.Application.InputModels;
using OrdemDeServico.Application.Services.Interfaces;
using OrdemDeServico.Application.ViewModels;
using OrdemDeServico.Domain.Entities;
using ResTIConnect.Infrastructure.Persistence;

namespace OrdemDeServico.Application.Services;

public class EnderecoService : IEnderecoService
{
    private readonly OrdemDeServicoContext _context;
    public EnderecoService(OrdemDeServicoContext context)
    {
        _context = context;
    }
    public int Create(NewEnderecoInputModel endereco)
    {
        var _endereco = MapEnderecoInputModelToEndereco(endereco);
        _endereco.CreatedAt = DateTime.UtcNow;
        _context.Enderecos.Add(_endereco);
        _context.SaveChanges();

        return _endereco.EnderecoId;
    }

    public ICollection<EnderecoViewModel> GetAll()
    {
        var _enderecos = _context.Enderecos.Select(endereco => MapEnderecoToEnderecoViewModel(endereco)).ToArray();
        return _enderecos;
    }

    public EnderecoViewModel? GetById(int id)
    {
        var _enderecoDb = GetByDbId(id);

        if (_enderecoDb is null)
        {
            return null;
        }

        var _endereco = MapEnderecoToEnderecoViewModel(_enderecoDb);
        return _endereco;
    }

    public void Update(int id, NewEnderecoInputModel endereco)
    {
        var _enderecoDb = GetByDbId(id);

        if (_enderecoDb is not null)
        {
            _enderecoDb.Logradouro = endereco.Logradouro;
            _enderecoDb.Bairro = endereco.Bairro;
            _enderecoDb.Numero = endereco.Numero;
            _enderecoDb.Complemento = endereco.Complemento;
            _enderecoDb.Cidade = endereco.Cidade;
            _enderecoDb.Estado = endereco.Estado;
            _enderecoDb.Pais = endereco.Pais;
            _enderecoDb.Cep = endereco.Cep;
            _enderecoDb.UpdatedAt = DateTime.UtcNow;
            _context.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var _enderecoDb = GetByDbId(id);

        if (_enderecoDb is not null)
        {
            _context.Enderecos.Remove(_enderecoDb);
            _context.SaveChanges();
        }
    }

    public Endereco MapEnderecoInputModelToEndereco(NewEnderecoInputModel endereco)
    {
        var _endereco = new Endereco
        {
            Logradouro = endereco.Logradouro,
            Bairro = endereco.Bairro,
            Numero = endereco.Numero,
            Complemento = endereco.Complemento,
            Cidade = endereco.Cidade,
            Estado = endereco.Estado,
            Pais = endereco.Pais,
            Cep = endereco.Cep,
        };

        return _endereco;
    }

    public EnderecoViewModel MapEnderecoToEnderecoViewModel(Endereco endereco)
    {
        var _endereco = new EnderecoViewModel
        {
            Logradouro = endereco.Logradouro,
            Bairro = endereco.Bairro,
            Numero = endereco.Numero,
            Complemento = endereco.Complemento,
            Cidade = endereco.Cidade,
            Estado = endereco.Estado,
            Pais = endereco.Pais,
            Cep = endereco.Cep,
        };

        return _endereco;
    }

    public Endereco? GetByDbId(int id)
    {
        var _endereco = _context.Enderecos.Find(id);

        if (_endereco is null)
        {
            return null;
        }

        return _endereco;
    }
}
