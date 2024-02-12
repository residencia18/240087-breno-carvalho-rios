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
    public ClienteService(OrdemDeServicoContext context, IEnderecoService enderecoservice)
    {
        _context = context;
        _enderecoService = enderecoservice;
    }
    public int Create(NewClienteInputModel cliente)
    {
        var _cliente = MapClienteInputModelToCliente(cliente);
        _cliente.CreatedAt = DateTime.UtcNow;
        _context.Clientes.Add(_cliente);
        _context.SaveChanges();

        return _cliente.ClienteId;
    }

    public ICollection<ClienteViewModel> GetAll()
    {
        var _clientes = _context.Clientes.Select(cliente => MapClienteToClienteViewModel(cliente)).ToArray();

        return _clientes;
    }

    public ClienteViewModel? GetById(int id)
    {
        var _clienteDb = GetByDbId(id);

        if (_clienteDb is null)
        {
            return null;
        }

        var _cliente = MapClienteToClienteViewModel(_clienteDb);
        return _cliente;
    }

    public void Update(int id, NewClienteInputModel cliente)
    {
        var _clienteDb = GetByDbId(id);

        if (_clienteDb is not null)
        {
            _clienteDb.Nome = cliente.Nome;
            _clienteDb.Email = cliente.Email;
            _clienteDb.Telefone = cliente.Telefone;
            _clienteDb.Endereco = _enderecoService.MapEnderecoInputModelToEndereco(cliente.Endereco);
            _clienteDb.UpdatedAt = DateTime.UtcNow;
            _context.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var _clienteDb = GetByDbId(id);

        if (_clienteDb is not null)
        {
            _context.Clientes.Remove(_clienteDb);
            _context.SaveChanges();
        }
    }

    public Cliente MapClienteInputModelToCliente(NewClienteInputModel cliente)
    {
        var _cliente = new Cliente
        {
            Nome = cliente.Nome,
            Email = cliente.Email,
            Telefone = cliente.Telefone,
            Endereco = _enderecoService.MapEnderecoInputModelToEndereco(cliente.Endereco)
        };

        return _cliente;
    }

    public ClienteViewModel MapClienteToClienteViewModel(Cliente cliente)
    {
        var _cliente = new ClienteViewModel
        {
            ClienteId = cliente.ClienteId,
            Nome = cliente.Nome,
            Email = cliente.Email,
            Telefone = cliente.Telefone,
            Endereco = _enderecoService.MapEnderecoToEnderecoViewModel(cliente.Endereco)
        };

        return _cliente;
    }

    private Cliente? GetByDbId(int id)
    {
        var _cliente = _context.Clientes.Find(id);

        if (_cliente is null)
        {
            return null;
        }

        return _cliente;
    }
}
