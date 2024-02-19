using OrdemDeServico.Application.InputModels;
using OrdemDeServico.Application.Services.Interfaces;
using OrdemDeServico.Application.ViewModels;
using OrdemDeServico.Domain.Entities;
using ResTIConnect.Infrastructure.Persistence;

namespace OrdemDeServico.Application.Services;

public class ClienteService : IClienteService
{
    private readonly OrdemDeServicoContext _context;
    private readonly IEnderecoService _enderecoService;
    public ClienteService(OrdemDeServicoContext context, IEnderecoService enderecoService)
    {
        _context = context;
        _enderecoService = enderecoService;
    }
    public int Create(NewClienteInputModel cliente)
    {
        var _cliente = new Cliente
        {
            Nome = cliente.Nome,
            Email = cliente.Email,
            Telefone = cliente.Telefone,
            Endereco = new Endereco
            {
                Logradouro = cliente.Endereco.Logradouro,
                Bairro = cliente.Endereco.Bairro,
                Numero = cliente.Endereco.Numero,
                Complemento = cliente.Endereco.Complemento,
                Cidade = cliente.Endereco.Cidade,
                Estado = cliente.Endereco.Estado,
                Pais = cliente.Endereco.Pais,
                Cep = cliente.Endereco.Cep,
            },
            CreatedAt = DateTime.UtcNow,
        };
        _context.Clientes.Add(_cliente);
        _context.SaveChanges();

        return _cliente.ClienteId;
    }

    public ICollection<ClienteViewModel> GetAll()
    {
        var _clientes = _context.Clientes.Select(cliente => new ClienteViewModel
        {
            ClienteId = cliente.ClienteId,
            Nome = cliente.Nome,
            Email = cliente.Email,
            Telefone = cliente.Telefone,
            Endereco = new EnderecoViewModel
            {
                EnderecoId = cliente.Endereco.EnderecoId,
                Logradouro = cliente.Endereco.Logradouro,
                Bairro = cliente.Endereco.Bairro,
                Numero = cliente.Endereco.Numero,
                Complemento = cliente.Endereco.Complemento,
                Cidade = cliente.Endereco.Cidade,
                Estado = cliente.Endereco.Estado,
                Pais = cliente.Endereco.Pais,
                Cep = cliente.Endereco.Cep,
            }
        }).ToArray();

        return _clientes;
    }

    public ClienteViewModel? GetById(int id)
    {
        var _cliente = _context.Clientes.Find(id);

        if (_cliente is null)
        {
            return null;
        }

        var _endereco = _enderecoService.GetById(_cliente.EnderecoId);

        if (_endereco is null)
        {
            return null;
        }

        var _clienteViewModel = new ClienteViewModel
        {
            ClienteId = _cliente.ClienteId,
            Nome = _cliente.Nome,
            Email = _cliente.Email,
            Telefone = _cliente.Telefone,
            Endereco = _endereco
        };

        return _clienteViewModel;
    }

    public void Update(int id, NewClienteInputModel cliente)
    {
        var _clienteDb = _context.Clientes.Find(id);

        if (_clienteDb is not null)
        {
            _clienteDb.Nome = cliente.Nome;
            _clienteDb.Email = cliente.Email;
            _clienteDb.Telefone = cliente.Telefone;
            _enderecoService.Update(_clienteDb.EnderecoId, cliente.Endereco);
            _clienteDb.UpdatedAt = DateTime.UtcNow;
            _context.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var _clienteDb = _context.Clientes.Find(id);

        if (_clienteDb is not null)
        {
            _context.Clientes.Remove(_clienteDb);
            _context.SaveChanges();
        }
    }

    public List<ClienteViewModel> GetByTelefone(string telefone)
    {
        var clientes = _context.Clientes
            .Where(cliente => cliente.Telefone == telefone)
            .Select(cliente => new ClienteViewModel
            {
                ClienteId = cliente.ClienteId,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Telefone = cliente.Telefone,
                Endereco = new EnderecoViewModel
                {
                    EnderecoId = cliente.Endereco.EnderecoId,
                    Logradouro = cliente.Endereco.Logradouro,
                    Numero = cliente.Endereco.Numero,
                    Bairro = cliente.Endereco.Bairro,
                    Complemento = cliente.Endereco.Complemento,
                    Estado = cliente.Endereco.Estado,
                    Cidade = cliente.Endereco.Cidade,
                    Cep = cliente.Endereco.Cep,
                    Pais = cliente.Endereco.Pais
                }
            }).ToList();

        return clientes;
    }
}
