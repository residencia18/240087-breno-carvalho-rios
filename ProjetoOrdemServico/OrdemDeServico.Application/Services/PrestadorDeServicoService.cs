using OrdemDeServico.Application.InputModels;
using OrdemDeServico.Application.Services.Interfaces;
using OrdemDeServico.Domain.Entities;
using ResTIConnect.Infrastructure;

namespace OrdemDeServico.Application.Services;

public class PrestadorDeServicoService : IPrestadorDeServicoService
{
    private readonly OrdemDeServicoContext _context;
    private readonly IEnderecoService _enderecoservice;
    public PrestadorDeServicoService(OrdemDeServicoContext context, IEnderecoService enderecoservice)
    {
        _context = context;
        _enderecoservice = enderecoservice;

    }
    public int Create(NewPrestadorDeServicoInputModel prestadorDeServico)
    {
        var _prestadorDeServico = MapPrestadorDeServicoInputModelToPrestadorDeServico(prestadorDeServico);
        _context.PrestadoresDeServico.Add(_prestadorDeServico);
        _context.SaveChanges();

        return _prestadorDeServico.PrestadorDeServicoId;
    }

    public void Delete(int id)
    {
        var _prestadorDeServicoDb = GetByDbId(id);

        if (_prestadorDeServicoDb is not null)
        {
            _context.PrestadoresDeServico.Remove(_prestadorDeServicoDb);
            _context.SaveChanges();
        }
    }

    public void Update(int id, NewPrestadorDeServicoInputModel prestadorDeServico)
    {
        var _prestadorDeServicoDb = GetByDbId(id);

        if (_prestadorDeServicoDb is not null)
        {
            _prestadorDeServicoDb.Nome = prestadorDeServico.Nome;
            _prestadorDeServicoDb.Especialidade = prestadorDeServico.Especialidade;
            _prestadorDeServicoDb.Telefone = prestadorDeServico.Telefone;
            _prestadorDeServicoDb.Endereco = _enderecoservice.MapEnderecoInputModelToEndereco(prestadorDeServico.Endereco);
            _context.SaveChanges();
        }
    }

    public ICollection<PrestadorDeServicoViewModel> GetAll()
    {
        var _prestadoresDeServico = _context.PrestadoresDeServico.Select(prestadorDeServico => MapPrestadorDeServicoToPrestadorDeServicoViewModel(prestadorDeServico)).ToArray();

        return _prestadoresDeServico;
    }

    public PrestadorDeServicoViewModel? GetById(int id)
    {
        var _prestadorDeServicoDb = GetByDbId(id);

        if (_prestadorDeServicoDb is null)
        {
            return null;
        }

        var _prestadorDeServico = MapPrestadorDeServicoToPrestadorDeServicoViewModel(_prestadorDeServicoDb);
        return _prestadorDeServico;
    }

    public PrestadorDeServico MapPrestadorDeServicoInputModelToPrestadorDeServico(NewPrestadorDeServicoInputModel prestadorDeServico)
    {
        var _prestadorDeServico = new PrestadorDeServico
        {
            Nome = prestadorDeServico.Nome,
            Especialidade = prestadorDeServico.Especialidade,
            Telefone = prestadorDeServico.Telefone,
            Endereco = _enderecoservice.MapEnderecoInputModelToEndereco(prestadorDeServico.Endereco)
        };

        return _prestadorDeServico;
    }

    public PrestadorDeServicoViewModel MapPrestadorDeServicoToPrestadorDeServicoViewModel(PrestadorDeServico prestadorDeServico)
    {
        var _prestadorDeServico = new PrestadorDeServicoViewModel
        {
            PrestadorDeServicoId = prestadorDeServico.PrestadorDeServicoId,
            Nome = prestadorDeServico.Nome,
            Especialidade = prestadorDeServico.Especialidade,
            Telefone = prestadorDeServico.Telefone,
            Endereco = _enderecoservice.MapEnderecoToEnderecoViewModel(prestadorDeServico.Endereco)
        };

        return _prestadorDeServico;
    }

    private PrestadorDeServico? GetByDbId(int id)
    {
        var _prestadorDeServico = _context.PrestadoresDeServico.Find(id);

        if (_prestadorDeServico is null)
        {
            return null;
        }

        return _prestadorDeServico;
    }
}
