namespace OrdemDeServico.Application;

public interface IBaseService<TInputModel, TViewModel>
{
    public ICollection<TViewModel> GetAll();
    public TViewModel? GetById(int id);
    public int Create(TInputModel cliente);
    public void Update(int id, TInputModel cliente);
    public void Delete(int id);
}
