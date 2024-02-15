namespace TechMed.Application.Services.InterfacesServices;

public interface IBaseService<TInputModel, TViewModel, TEntityModel>
    where TViewModel : class
    where TInputModel : class
    where TEntityModel : class
{
    List<TViewModel> GetAll();
    TViewModel? GetById(int id);
    int Create(TInputModel entity);
    void Update(int id, TInputModel entity);
    void Delete(int id);
    TEntityModel GetByDbId(int id);
}

