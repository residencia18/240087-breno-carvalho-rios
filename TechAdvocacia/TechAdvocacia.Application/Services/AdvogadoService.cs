using TechAdvocacia.Application.InputModels;
using TechAdvocacia.Application.Services.Interfaces;
using TechAdvocacia.Application.ViewModels;
using TechAdvocacia.Core.Entities;
using TechAdvocacia.Core.Exceptions;
using TechAdvocacia.Infrastructure.Persistence;

namespace TechAdvocacia.Application.Services;
public class AdvogadoService : IAdvogadoService
{
    private readonly TechAdvocaciaDbContext _context;
    public AdvogadoService(TechAdvocaciaDbContext context)
    {
        _context = context;
    }

    public int Create(NewAdvogadoInputModel advogado)
    {
        var _advogado = new Advogado
        {
            Nome = advogado.Nome
        };

        _context.Advogados.Add(_advogado);
        _context.SaveChanges();

        return _advogado.AdvogadoId;
    }

    public void Delete(int id)
    {
        var _advogado = GetDbAdvogado(id);

        _context.Advogados.Remove(_advogado);
        _context.SaveChanges();
    }

    public ICollection<AdvogadoViewModel> GetAll()
    {
        var advogados = _context.Advogados.Select(advogado => new AdvogadoViewModel()
        {
            AdvogadoId = advogado.AdvogadoId,
            Nome = advogado.Nome
        });

        return advogados.ToList();
    }

    public AdvogadoViewModel GetById(int id)
    {
        var _advogado = GetDbAdvogado(id);

        return new AdvogadoViewModel
        {
            AdvogadoId = _advogado.AdvogadoId,
            Nome = _advogado.Nome
        };
    }

    public void Update(int id, NewAdvogadoInputModel advogado)
    {
        var _advogado = GetDbAdvogado(id);

        _advogado.Nome = _advogado.Nome;
    
        _context.Advogados.Update(_advogado);
        _context.SaveChanges();
    }

    public Advogado GetDbAdvogado(int id)
    {
        var _advogado = _context.Advogados.FirstOrDefault(advogado => advogado.AdvogadoId == id);

        if(_advogado is null){
            throw new AdvogadoNotFoundException();
        }

        return _advogado;
    }
}
