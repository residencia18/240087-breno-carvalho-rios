using OrdemDeServico.Application.InputModels;
using OrdemDeServico.Application.Services.Interfaces;
using OrdemDeServico.Application.ViewModels;
using OrdemDeServico.Domain;
using OrdemDeServico.Domain.Entities;
using ResTIConnect.Infrastructure.Persistence;

namespace OrdemDeServico.Application.Services;

public class PagamentoService : IPagamentoService
{
    private readonly OrdemDeServicoContext _context;

    public PagamentoService(OrdemDeServicoContext context)
    {
        _context = context;
    }

    public int Create(NewPagamentoInputModel pagamento)
    {
        var _ordemServico = _context.OrdensServico.Find(pagamento.OrdemServicoId) ?? throw new OrdemServicoNotFoundException();
        var _pagamento = new Pagamento
        {
            Valor = pagamento.Valor,
            DataPagamento = pagamento.DataPagamento,
            MetodoPagamento = pagamento.MetodoPagamento,
            OrdemServicoId = _ordemServico.OrdemServicoId
        };
        _context.Pagamentos.Add(_pagamento);
        _context.SaveChanges();

        return _pagamento.PagamentoId;

    }

    public ICollection<PagamentoViewModel> GetAll()
    {
        var _pagamentos = _context.Pagamentos.Select(pagamento => new PagamentoViewModel
        {
            PagamentoId = pagamento.PagamentoId,
            Valor = pagamento.Valor,
            DataPagamento = pagamento.DataPagamento,
            MetodoPagamento = pagamento.MetodoPagamento
        }).ToList();

        return _pagamentos;
    }

    public PagamentoViewModel? GetById(int id)
    {
        var _pagamento = _context.Pagamentos.Find(id);

        if (_pagamento is null)
        {
            return null;
        }

        var _pagamentoViewModel = new PagamentoViewModel
        {
            PagamentoId = _pagamento.PagamentoId,
            Valor = _pagamento.Valor,
            DataPagamento = _pagamento.DataPagamento,
            MetodoPagamento = _pagamento.MetodoPagamento
        };

        return _pagamentoViewModel;
    }

    public void Update(int id, NewPagamentoInputModel pagamento)
    {
        var _pagamento = _context.Pagamentos.Find(id);

        if (_pagamento is not null)
        {
            _pagamento.Valor = pagamento.Valor;
            _pagamento.DataPagamento = pagamento.DataPagamento;
            _pagamento.MetodoPagamento = pagamento.MetodoPagamento;
            _pagamento.UpdatedAt = DateTime.UtcNow;
            _context.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var pagamentoDb = _context.Pagamentos.Find(id);

        if (pagamentoDb is not null)
        {
            _context.Pagamentos.Remove(pagamentoDb);
            _context.SaveChanges();
        }
    }

    public List<PagamentoViewModel> GetPagamentoByMetodo(string metodoDePagamento)
    {
        var _pagamentos = _context.Pagamentos
            .Where(pagamento => pagamento.MetodoPagamento == metodoDePagamento)
            .Select(pagamento => new PagamentoViewModel
            {
                PagamentoId = pagamento.PagamentoId,
                Valor = pagamento.Valor,
                DataPagamento = pagamento.DataPagamento,
                MetodoPagamento = pagamento.MetodoPagamento
            }).ToList();

        return _pagamentos;
    }
}
