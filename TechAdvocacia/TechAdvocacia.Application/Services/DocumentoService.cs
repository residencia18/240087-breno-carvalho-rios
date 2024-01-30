using System.Runtime.InteropServices;
using TechAdvocacia.Application.InputModels;
using TechAdvocacia.Application.Services.Interfaces;
using TechAdvocacia.Application.ViewModels;
using TechAdvocacia.Core.Entities;
using TechAdvocacia.Core.Exceptions;
using TechAdvocacia.Infrastructure.Persistence;

namespace TechAdvocacia.Application.Services;
public class DocumentoService : IDocumentoService
{
    private readonly TechAdvocaciaDbContext _context;
    private readonly ICasoJuridicoService _casoJuridicoService;
    public DocumentoService(TechAdvocaciaDbContext context, ICasoJuridicoService casoJuridicoService)
    {
        _context = context;
        _casoJuridicoService = casoJuridicoService;
    }
    public int Create(NewDocumentoInputModel documento)
    {
        var _casoJuridico = _context.CasosJuridicos.FirstOrDefault(cj => cj.CasoJuridicoId == documento.CasoJuridicoId);

        if (_casoJuridico is null){
            throw new CasoJuridicoNotFoundException();
        }

        var _documento = new Documento
        {
            Descricao = documento.Descricao,
            CasoJuridico = _casoJuridico,
        };

        _context.Documentos.Add(_documento);
        _context.SaveChanges();

        return _documento.DocumentoId;
    }

    public void Delete(int id)
    {
        var _documento = GetDbDocumento(id);

        _context.Documentos.Remove(_documento);
    }

    public ICollection<DocumentoViewModel> GetAll()
    {
        var documentos = _context.Documentos.Select(documento => new DocumentoViewModel()
        {
            DocumentoId = documento.DocumentoId,
            Descricao = documento.Descricao,
            CasoJuridico = _casoJuridicoService.GetById(documento.CasoJuridicoId),
        });

        return documentos.ToList();
    }

    public DocumentoViewModel GetById(int id)
    {
        var _documento = GetDbDocumento(id);

        return new DocumentoViewModel
        {
            DocumentoId = _documento.DocumentoId,
            Descricao = _documento.Descricao,
            CasoJuridico = _casoJuridicoService.GetById(_documento.CasoJuridicoId)
        };
    }

    public void Update(int id, NewDocumentoInputModel documento)
    {
        var _documento = GetDbDocumento(id);

        _documento.Descricao = _documento.Descricao;
        
        _context.Documentos.Update(_documento);
        _context.SaveChanges();
    }

    public Documento GetDbDocumento(int id)
    {
        var _documento = _context.Documentos.FirstOrDefault(d => d.DocumentoId == id);

        if(_documento is null){
            throw new DocumentoNotFoundException();
        }

        return _documento;
    }
}
