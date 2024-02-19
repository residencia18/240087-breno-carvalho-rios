using OrdemDeServico.Application.InputModels;
using OrdemDeServico.Application.Services.Interfaces;
using OrdemDeServico.Application.ViewModels;
using OrdemDeServico.Domain.Entities;
using ResTIConnect.Infrastructure.Persistence;

namespace OrdemDeServico.Application.Services;

public class PrestadorDeServicoService : IPrestadorDeServicoService
{
    private readonly OrdemDeServicoContext _context;
    private readonly IEnderecoService _enderecoService;
    public PrestadorDeServicoService(OrdemDeServicoContext context, IEnderecoService enderecoService)
    {
        _context = context;
        _enderecoService = enderecoService;
    }
    public int Create(NewPrestadorDeServicoInputModel prestadorDeServico)
    {
        var _prestadorDeServico = new PrestadorDeServico
        {
            Nome = prestadorDeServico.Nome,
            Especialidade = prestadorDeServico.Especialidade,
            Telefone = prestadorDeServico.Telefone,
            Endereco = new Endereco
            {
                Logradouro = prestadorDeServico.Endereco.Logradouro,
                Bairro = prestadorDeServico.Endereco.Bairro,
                Numero = prestadorDeServico.Endereco.Numero,
                Complemento = prestadorDeServico.Endereco.Complemento,
                Cidade = prestadorDeServico.Endereco.Cidade,
                Estado = prestadorDeServico.Endereco.Estado,
                Pais = prestadorDeServico.Endereco.Pais,
                Cep = prestadorDeServico.Endereco.Cep,
                CreatedAt = DateTime.UtcNow,
            }
        };
        _context.PrestadoresDeServico.Add(_prestadorDeServico);
        _context.SaveChanges();

        return _prestadorDeServico.PrestadorDeServicoId;
    }

    public void Delete(int id)
    {
        var _prestadorDeServicoDb = _context.PrestadoresDeServico.Find(id);

        if (_prestadorDeServicoDb is not null)
        {
            _context.PrestadoresDeServico.Remove(_prestadorDeServicoDb);
            _context.SaveChanges();
        }
    }

    public void Update(int id, NewPrestadorDeServicoInputModel prestadorDeServico)
    {
        var _prestadorDeServicoDb = _context.PrestadoresDeServico.Find(id);

        if (_prestadorDeServicoDb is null)
        {
            return;
        }

        _prestadorDeServicoDb.Nome = prestadorDeServico.Nome;
        _prestadorDeServicoDb.Especialidade = prestadorDeServico.Especialidade;
        _prestadorDeServicoDb.Telefone = prestadorDeServico.Telefone;
        _enderecoService.Update(_prestadorDeServicoDb.EnderecoId, prestadorDeServico.Endereco);
        _prestadorDeServicoDb.UpdatedAt = DateTime.UtcNow;

        _context.PrestadoresDeServico.Update(_prestadorDeServicoDb);
        _context.SaveChanges();
    }

    public ICollection<PrestadorDeServicoViewModel> GetAll()
    {
        var _prestadoresDeServico = _context.PrestadoresDeServico.Select(prestadorDeServico => new PrestadorDeServicoViewModel
        {
            PrestadorDeServicoId = prestadorDeServico.PrestadorDeServicoId,
            Nome = prestadorDeServico.Nome,
            Especialidade = prestadorDeServico.Especialidade,
            Telefone = prestadorDeServico.Telefone,
            Endereco = new EnderecoViewModel
            {
                Logradouro = prestadorDeServico.Endereco.Logradouro,
                Bairro = prestadorDeServico.Endereco.Bairro,
                Numero = prestadorDeServico.Endereco.Numero,
                Complemento = prestadorDeServico.Endereco.Complemento,
                Cidade = prestadorDeServico.Endereco.Cidade,
                Estado = prestadorDeServico.Endereco.Estado,
                Pais = prestadorDeServico.Endereco.Pais,
                Cep = prestadorDeServico.Endereco.Cep,
            }
        }).ToArray();

        return _prestadoresDeServico;
    }

    public PrestadorDeServicoViewModel? GetById(int id)
    {
        var _prestadorDeServicoDb = _context.PrestadoresDeServico.Find(id);

        if (_prestadorDeServicoDb is null)
        {
            return null;
        }

        var _endereco = _enderecoService.GetById(_prestadorDeServicoDb.EnderecoId);

        if (_endereco is null)
        {
            return null;
        }

        var _prestadorDeServico = new PrestadorDeServicoViewModel
        {
            PrestadorDeServicoId = _prestadorDeServicoDb.PrestadorDeServicoId,
            Nome = _prestadorDeServicoDb.Nome,
            Especialidade = _prestadorDeServicoDb.Especialidade,
            Telefone = _prestadorDeServicoDb.Telefone,
            Endereco = new EnderecoViewModel
            {
                EnderecoId = _prestadorDeServicoDb.Endereco.EnderecoId,
                Logradouro = _prestadorDeServicoDb.Endereco.Logradouro,
                Bairro = _prestadorDeServicoDb.Endereco.Bairro,
                Numero = _prestadorDeServicoDb.Endereco.Numero,
                Complemento = _prestadorDeServicoDb.Endereco.Complemento,
                Cidade = _prestadorDeServicoDb.Endereco.Cidade,
                Estado = _prestadorDeServicoDb.Endereco.Estado,
                Pais = _prestadorDeServicoDb.Endereco.Pais,
                Cep = _prestadorDeServicoDb.Endereco.Cep,
            }
        };
        return _prestadorDeServico;
    }
    public List<PrestadorDeServicoViewModel> GetByEspecialidade(string especialidade)
    {
        var _prestadoresDeServico = _context.PrestadoresDeServico
            .Where(prestadorDeServico => prestadorDeServico.Especialidade == especialidade)
            .Select(prestadorDeServico => new PrestadorDeServicoViewModel
            {
                PrestadorDeServicoId = prestadorDeServico.PrestadorDeServicoId,
                Nome = prestadorDeServico.Nome,
                Especialidade = prestadorDeServico.Especialidade,
                Telefone = prestadorDeServico.Telefone,
                Endereco = new EnderecoViewModel
                {
                    Logradouro = prestadorDeServico.Endereco.Logradouro,
                    Bairro = prestadorDeServico.Endereco.Bairro,
                    Numero = prestadorDeServico.Endereco.Numero,
                    Complemento = prestadorDeServico.Endereco.Complemento,
                    Cidade = prestadorDeServico.Endereco.Cidade,
                    Estado = prestadorDeServico.Endereco.Estado,
                    Pais = prestadorDeServico.Endereco.Pais,
                    Cep = prestadorDeServico.Endereco.Cep,
                }
            }).ToList();

        return _prestadoresDeServico;
    }
}
