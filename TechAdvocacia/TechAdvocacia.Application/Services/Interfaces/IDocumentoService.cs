using TechAdvocacia.Application.InputModels;
using TechAdvocacia.Application.ViewModels;
using TechAdvocacia.Core.Entities;

namespace TechAdvocacia.Application.Services.Interfaces;
public interface IDocumentoService
{
    public int Create(NewDocumentoInputModel documento);
    public void Update(int id, NewDocumentoInputModel documento);
    public void Delete(int id);
    public DocumentoViewModel GetById(int id);
    public ICollection<DocumentoViewModel> GetAll();
}
