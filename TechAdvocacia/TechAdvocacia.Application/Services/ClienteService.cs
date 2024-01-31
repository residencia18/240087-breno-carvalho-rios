using TechAdvocacia.Application.InputModels;
using TechAdvocacia.Application.Services.Interfaces;
using TechAdvocacia.Application.ViewModels;
using TechAdvocacia.Core.Entities;
using TechAdvocacia.Core.Exceptions;
using TechAdvocacia.Infrastructure.Persistence;

namespace TechAdvocacia.Application.Services;
public class ClienteService : IClienteService
{
    private readonly TechAdvocaciaDbContext _context;
    public ClienteService(TechAdvocaciaDbContext context)
    {
        _context = context;
    }

    public int Create(NewClientInputModel cliente)
    {
        var _cliente = new Cliente
        {
            Nome = cliente.Nome
        };

        _context.Clientes.Add(_cliente);
        _context.SaveChanges();

        return _cliente.ClienteId;
    }

    public void Delete(int id)
    {
        var _cliente = GetDbClient(id);

        _context.Clientes.Remove(_cliente);
        _context.SaveChanges();
    }

    public List<ClienteViewModel> GetAll()
    {
        var _clientes = _context.Clientes.Select(cliente => new ClienteViewModel()
        {
            ClienteId = cliente.ClienteId,
            Nome = cliente.Nome
        });

        return _clientes.ToList();
    }

    public ClienteViewModel GetById(int id)
    {
        var _cliente = GetDbClient(id);

        return new ClienteViewModel
        {
            ClienteId = _cliente.ClienteId,
            Nome = _cliente.Nome
        };
    }

    public void Update(int id, NewClientInputModel cliente)
    {
        var _cliente = GetDbClient(id);

        _cliente.Nome = cliente.Nome;

        _context.Clientes.Update(_cliente);
        _context.SaveChanges();
    }

    public Cliente GetDbClient(int id)
    {
        var _cliente = _context.Clientes.FirstOrDefault(cliente => cliente.ClienteId == id);

        if (_cliente is null)
        {
            throw new ClienteNotFoundException();
        }

        return _cliente;
    }
}
