namespace OrdemDeServico.Application.Services.Interfaces;

public interface IBaseService<TInputModel, TViewModel>
{
    public ICollection<TViewModel> GetAll();
    public TViewModel? GetById(int id);
    public int Create(TInputModel entity);
    public void Update(int id, TInputModel entity);
    public void Delete(int id);
}
