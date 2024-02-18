using OrdemDeServico.Application.InputModels;
using OrdemDeServico.Application.Services.Interfaces;
using OrdemDeServico.Application.ViewModels;
using OrdemDeServico.Domain;
using OrdemDeServico.Domain.Entities;
using OrdemDeServico.Domain.Exceptions;
using ResTIConnect.Infrastructure.Persistence;

namespace OrdemDeServico.Application.Services;

public class OrdemServicoService : IOrdemServicoService
{
    private readonly OrdemDeServicoContext _context;
    private readonly IClienteService _clienteService;
    private readonly IPrestadorDeServicoService _prestadorDeServicoService;
    public OrdemServicoService(OrdemDeServicoContext context, IClienteService clienteService, IPrestadorDeServicoService prestadorDeServicoService)
    {
        _context = context;
        _clienteService = clienteService;
        _prestadorDeServicoService = prestadorDeServicoService;
    }
    public int Create(NewOrdemServicoInputModel ordemServico)
    {
        var _cliente = _context.Clientes.Find(ordemServico.ClienteId) ?? throw new ClienteNotFoundException();
        var _prestadorDeServico = _context.PrestadoresDeServico.Find(ordemServico.PrestadorDeServicoId) ?? throw new PrestadorDeServicoNotFoundException();

        var _ordemServico = new OrdemServico
        {
            Numero = ordemServico.Numero,
            Descricao = ordemServico.Descricao,
            DataDeEmissao = ordemServico.DataDeEmissao,
            Status = ordemServico.Status,
            ClienteId = _cliente.ClienteId,
            PrestadorDeServicoId = _prestadorDeServico.PrestadorDeServicoId,
            CreatedAt = DateTime.UtcNow
        };

        _context.OrdensServico.Add(_ordemServico);
        _context.SaveChanges();


        foreach (var servico in ordemServico.Servicos)
        {
            var _servico = _context.Servicos.Find(servico.ServicoId) ?? throw new ServicoNotFoundException();
            var _endereco = new Endereco
            {
                Logradouro = servico.Endereco.Logradouro,
                Bairro = servico.Endereco.Bairro,
                Numero = servico.Endereco.Numero,
                Complemento = servico.Endereco.Complemento,
                Cidade = servico.Endereco.Cidade,
                Estado = servico.Endereco.Estado,
                Pais = servico.Endereco.Pais,
                Cep = servico.Endereco.Cep,
            };

            var _servicoOrdemServico = new ServicoOrdemServico
            {
                OrdemServicoId = _ordemServico.OrdemServicoId,
                ServicoId = _servico.ServicoId,
                Endereco = _endereco
            };

            _context.ServicosOrdensServico.Add(_servicoOrdemServico);
        }

        _context.SaveChanges();

        return _ordemServico.OrdemServicoId;
    }

    public void Delete(int id)
    {
        var _ordemServico = _context.OrdensServico.Find(id) ?? throw new OrdemServicoNotFoundException();

        foreach (var servicoOrdemServico in _context.ServicosOrdensServico.Where(servico => servico.OrdemServicoId == _ordemServico.OrdemServicoId).ToList())
        {
            var _endereco = _context.Enderecos.Find(servicoOrdemServico.EnderecoId) ?? throw new EnderecoNotFoundException();
            _context.Enderecos.Remove(_endereco);
            _context.ServicosOrdensServico.Remove(servicoOrdemServico);
        }

        _context.OrdensServico.Remove(_ordemServico);
        _context.SaveChanges();
    }

    public ICollection<OrdemServicoViewModel> GetAll()
    {
        return _context.OrdensServico.Select(ordemServico => new OrdemServicoViewModel
        {
            OrdemServicoId = ordemServico.OrdemServicoId,
            Numero = ordemServico.Numero,
            Descricao = ordemServico.Descricao,
            DataDeEmissao = ordemServico.DataDeEmissao,
            Status = ordemServico.Status,
            Cliente = new ClienteViewModel
            {
                ClienteId = ordemServico.Cliente!.ClienteId,
                Nome = ordemServico.Cliente!.Nome,
                Email = ordemServico.Cliente!.Email,
                Telefone = ordemServico.Cliente!.Telefone,
                Endereco = new EnderecoViewModel
                {
                    EnderecoId = ordemServico.Cliente!.Endereco.EnderecoId,
                    Logradouro = ordemServico.Cliente!.Endereco.Logradouro,
                    Bairro = ordemServico.Cliente!.Endereco.Bairro,
                    Numero = ordemServico.Cliente!.Endereco.Numero,
                    Complemento = ordemServico.Cliente!.Endereco.Complemento,
                    Cidade = ordemServico.Cliente!.Endereco.Cidade,
                    Estado = ordemServico.Cliente!.Endereco.Estado,
                    Pais = ordemServico.Cliente!.Endereco.Pais,
                    Cep = ordemServico.Cliente!.Endereco.Cep,
                }
            },
            PrestadorDeServico = new PrestadorDeServicoViewModel
            {
                PrestadorDeServicoId = ordemServico.PrestadorDeServico!.PrestadorDeServicoId,
                Nome = ordemServico.PrestadorDeServico!.Nome,
                Especialidade = ordemServico.PrestadorDeServico!.Especialidade,
                Telefone = ordemServico.PrestadorDeServico!.Telefone,
                Endereco = new EnderecoViewModel
                {
                    Logradouro = ordemServico.PrestadorDeServico!.Endereco.Logradouro,
                    Bairro = ordemServico.PrestadorDeServico!.Endereco.Bairro,
                    Numero = ordemServico.PrestadorDeServico!.Endereco.Numero,
                    Complemento = ordemServico.PrestadorDeServico!.Endereco.Complemento,
                    Cidade = ordemServico.PrestadorDeServico!.Endereco.Cidade,
                    Estado = ordemServico.PrestadorDeServico!.Endereco.Estado,
                    Pais = ordemServico.PrestadorDeServico!.Endereco.Pais,
                    Cep = ordemServico.PrestadorDeServico!.Endereco.Cep,
                }
            },
            Servicos = _context.ServicosOrdensServico
                .Where(servicoOrdemServico => servicoOrdemServico.OrdemServicoId == ordemServico.OrdemServicoId)
                .Select(servicoOrdemServico => new ServicoOrdemServicoViewModel
                {
                    Servico = new ServicoViewModel
                    {
                        ServicoId = servicoOrdemServico.Servico!.ServicoId,
                        Nome = servicoOrdemServico.Servico!.Nome,
                        Descricao = servicoOrdemServico.Servico!.Descricao,
                        Precos = servicoOrdemServico.Servico!.Precos
                    },
                    Endereco = new EnderecoViewModel
                    {
                        EnderecoId = servicoOrdemServico.Endereco!.EnderecoId,
                        Logradouro = servicoOrdemServico.Endereco!.Logradouro,
                        Bairro = servicoOrdemServico.Endereco!.Bairro,
                        Numero = servicoOrdemServico.Endereco!.Numero,
                        Complemento = servicoOrdemServico.Endereco!.Complemento,
                        Cidade = servicoOrdemServico.Endereco!.Cidade,
                        Estado = servicoOrdemServico.Endereco!.Estado,
                        Pais = servicoOrdemServico.Endereco!.Pais,
                        Cep = servicoOrdemServico.Endereco!.Cep,
                    }
                }).ToList(),
            Pagamentos = _context.Pagamentos.Select(pagamento => new PagamentoViewModel
            {
                PagamentoId = pagamento.PagamentoId,
                DataPagamento = pagamento.DataPagamento,
                MetodoPagamento = pagamento.MetodoPagamento,
                Valor = pagamento.Valor
            }).ToList()
        }).ToArray();
    }

    public OrdemServicoViewModel? GetById(int id)
    {
        var _ordemServicoDb = _context.OrdensServico.Find(id) ?? throw new OrdemServicoNotFoundException();
        var _cliente = _clienteService.GetById(_ordemServicoDb.ClienteId) ?? throw new ClienteNotFoundException();
        var _prestadorDeServico = _prestadorDeServicoService.GetById(_ordemServicoDb.PrestadorDeServicoId) ?? throw new PrestadorDeServicoNotFoundException();

        var _ordemServico = new OrdemServicoViewModel
        {
            OrdemServicoId = _ordemServicoDb.OrdemServicoId,
            Numero = _ordemServicoDb.Numero,
            Descricao = _ordemServicoDb.Descricao,
            DataDeEmissao = _ordemServicoDb.DataDeEmissao,
            Status = _ordemServicoDb.Status,
            Cliente = _cliente,
            PrestadorDeServico = _prestadorDeServico,
            Servicos = _context.ServicosOrdensServico
                .Where(servicoOrdemServico => servicoOrdemServico.OrdemServicoId == _ordemServicoDb.OrdemServicoId)
                .Select(servicoOrdemServico => new ServicoOrdemServicoViewModel
                {
                    Servico = new ServicoViewModel
                    {
                        ServicoId = servicoOrdemServico.Servico!.ServicoId,
                        Nome = servicoOrdemServico.Servico!.Nome,
                        Descricao = servicoOrdemServico.Servico!.Descricao,
                        Precos = servicoOrdemServico.Servico!.Precos
                    },
                    Endereco = new EnderecoViewModel
                    {
                        EnderecoId = servicoOrdemServico.Endereco!.EnderecoId,
                        Logradouro = servicoOrdemServico.Endereco!.Logradouro,
                        Bairro = servicoOrdemServico.Endereco!.Bairro,
                        Numero = servicoOrdemServico.Endereco!.Numero,
                        Complemento = servicoOrdemServico.Endereco!.Complemento,
                        Cidade = servicoOrdemServico.Endereco!.Cidade,
                        Estado = servicoOrdemServico.Endereco!.Estado,
                        Pais = servicoOrdemServico.Endereco!.Pais,
                        Cep = servicoOrdemServico.Endereco!.Cep,
                    }
                }).ToList(),
            Pagamentos = _context.Pagamentos.Select(pagamento => new PagamentoViewModel
            {
                PagamentoId = pagamento.PagamentoId,
                DataPagamento = pagamento.DataPagamento,
                MetodoPagamento = pagamento.MetodoPagamento,
                Valor = pagamento.Valor
            }).ToList()
        };

        return _ordemServico;
    }

    public void UpdateOrdemServico(int id, UpdateOrdemDeServicoInputModel ordemServico)
    {
        var _ordemServico = new NewOrdemServicoInputModel
        {
            Numero = ordemServico.Numero,
            DataDeEmissao = ordemServico.DataDeEmissao,
            Descricao = ordemServico.Descricao,
            Servicos = new List<AddServicoIntoOrdemServicoInputModel>(),
            Status = ordemServico.Status,
            ClienteId = ordemServico.ClienteId,
            PrestadorDeServicoId = ordemServico.PrestadorDeServicoId
        };
        Update(id, _ordemServico);
    }

    public void Update(int id, NewOrdemServicoInputModel ordemServico)
    {
        var _ordemServicoDb = _context.OrdensServico.Find(id) ?? throw new OrdemServicoNotFoundException();
        var _cliente = _context.Clientes.Find(ordemServico.ClienteId) ?? throw new ClienteNotFoundException();
        var _prestadorDeServico = _context.PrestadoresDeServico.Find(ordemServico.PrestadorDeServicoId) ?? throw new PrestadorDeServicoNotFoundException();

        _ordemServicoDb.Numero = ordemServico.Numero;
        _ordemServicoDb.Descricao = ordemServico.Descricao;
        _ordemServicoDb.DataDeEmissao = ordemServico.DataDeEmissao;
        _ordemServicoDb.Status = ordemServico.Status;
        _ordemServicoDb.ClienteId = _cliente.ClienteId;
        _ordemServicoDb.PrestadorDeServicoId = _prestadorDeServico.PrestadorDeServicoId;
        _ordemServicoDb.UpdatedAt = DateTime.UtcNow;

        _context.OrdensServico.Update(_ordemServicoDb);
        _context.SaveChanges();
    }

    public void AdicionaServico(int ordemServicoId, AddServicoIntoOrdemServicoInputModel servico)
    {
        var _ordemServicoDb = _context.OrdensServico.Find(ordemServicoId) ?? throw new OrdemServicoNotFoundException();
        var _servico = _context.Servicos.Find(servico.ServicoId) ?? throw new ServicoNotFoundException();

        _context.ServicosOrdensServico.Add(new ServicoOrdemServico
        {
            OrdemServicoId = _ordemServicoDb.OrdemServicoId,
            ServicoId = _servico.ServicoId,
            Endereco = new Endereco
            {
                Logradouro = servico.Endereco.Logradouro,
                Bairro = servico.Endereco.Bairro,
                Numero = servico.Endereco.Numero,
                Complemento = servico.Endereco.Complemento,
                Cidade = servico.Endereco.Cidade,
                Estado = servico.Endereco.Estado,
                Pais = servico.Endereco.Pais,
                Cep = servico.Endereco.Cep,
            }
        });

        _context.SaveChanges();
    }

    public void RemoveServico(int ordemServicoId, int servicoId)
    {
        var _ordemServicoDb = _context.OrdensServico.Find(ordemServicoId) ?? throw new OrdemServicoNotFoundException();
        var _servico = _context.Servicos.Find(servicoId) ?? throw new ServicoNotFoundException();

        var _servicoOrdemServico = _context.ServicosOrdensServico
            .FirstOrDefault(servicoOrdemServico =>
                servicoOrdemServico.OrdemServicoId == _ordemServicoDb.OrdemServicoId
                && servicoOrdemServico.ServicoId == _servico.ServicoId
            ) ?? throw new ServicoNotFoundException();

        var _endereco = _context.Enderecos.Find(_servicoOrdemServico.EnderecoId) ?? throw new EnderecoNotFoundException();

        _context.Enderecos.Remove(_endereco);
        _context.ServicosOrdensServico.Remove(_servicoOrdemServico);
        _context.SaveChanges();
    }
}
