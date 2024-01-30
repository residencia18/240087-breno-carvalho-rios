using TechAdvocacia.Application.InputModels;
using TechAdvocacia.Application.Services.Interfaces;
using TechAdvocacia.Application.ViewModels;
using TechAdvocacia.Core.Entities;
using TechAdvocacia.Core.Exceptions;
using TechAdvocacia.Infrastructure.Persistence;

namespace TechAdvocacia.Application.Services;
public class CasoJuridicoService : ICasoJuridicoService
{
    private readonly TechAdvocaciaDbContext _context;
    private readonly IAdvogadoService _advogadoService;
    private readonly IClienteService _clienteService;
    public CasoJuridicoService(
        TechAdvocaciaDbContext context,
        IAdvogadoService advogadoService,
        IClienteService clienteService
    )
    {
        _context = context;
        _advogadoService = advogadoService;
        _clienteService = clienteService;
    }

    public int Create(NewCasoJuridicoInputModel casoJuridico)
    {
        var _cliente = _context.Clientes.FirstOrDefault(c => c.ClienteId == casoJuridico.ClienteId);
        if(_cliente is null) {
            throw new ClienteNotFoundException();
        }

        var _advogado = _context.Advogados.FirstOrDefault(a => a.AdvogadoId == casoJuridico.AdvogadoId);
        if (_advogado is null){
            throw new AdvogadoNotFoundException();
        }

        var _casoJuridico = new CasoJuridico
        {
            ChanceSucesso = casoJuridico.ChanceSucesso,
            Status = casoJuridico.Status,
            Advogado = _advogado,
            Cliente = _cliente,
        };

        _context.CasosJuridicos.Add(_casoJuridico);
        _context.SaveChanges();

        return _casoJuridico.ClienteId;
    }

    public void Delete(int id)
    {
        var _casoJuridico = GetDbCasoJuridico(id);

        _context.CasosJuridicos.Remove(_casoJuridico);
        _context.SaveChanges();
    }

    public ICollection<CasoJuridicoViewModel> GetAll()
    {
        var _casosJuridicos = _context.CasosJuridicos.Select(cj => new CasoJuridicoViewModel()
        {
            CasoJuridicoId = cj.CasoJuridicoId,
            ChanceSucesso = cj.ChanceSucesso,
            Status = cj.Status,
            Advogado = _advogadoService.GetById(cj.AdvogadoId),
            Cliente = _clienteService.GetById(cj.ClienteId),
            Documentos = new List<DocumentoViewModel>()
            // Documentos = cj.Documentos.Select(
            //     documento => _documentoService.GetById(documento.DocumentoId)
            // ).ToList()
        });

        return _casosJuridicos.ToList();
    }

    public CasoJuridicoViewModel GetById(int id)
    {
        var _casoJuridico = GetDbCasoJuridico(id);

        // var _documentos = _casoJuridico.Documentos.Select(
        //     documento => _documentoService.GetById(documento.DocumentoId)
        // ).ToList();

        return new CasoJuridicoViewModel
        {
            ChanceSucesso = _casoJuridico.ChanceSucesso,
            Status = _casoJuridico.Status,
            Advogado = _advogadoService.GetById(_casoJuridico.AdvogadoId),
            Cliente = _clienteService.GetById(_casoJuridico.ClienteId),
            Documentos = new List<DocumentoViewModel>()
        };
    }

    public void Update(int id, NewCasoJuridicoInputModel casoJuridico)
    {
        var _casoJuridico = GetDbCasoJuridico(id);
        _casoJuridico.ChanceSucesso = casoJuridico.ChanceSucesso;
        _casoJuridico.Status = casoJuridico.Status;
        _context.Update(_casoJuridico);
        _context.SaveChanges();
    }

    public CasoJuridico GetDbCasoJuridico(int id)
    {
        var _casoJuridico = _context.CasosJuridicos.FirstOrDefault(cj => cj.CasoJuridicoId == id);

        if (_casoJuridico is null)
        {
            throw new CasoJuridicoNotFoundException();
        }

        return _casoJuridico;
    }
}
