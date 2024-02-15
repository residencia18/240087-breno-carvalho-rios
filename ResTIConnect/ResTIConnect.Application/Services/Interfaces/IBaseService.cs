namespace ResTIConnect.Application.Services.Interfaces
{
    public interface IBaseService<TInputModel, TViewModel, TEntityModel>
    {
        List<TViewModel> GetAll();
        TViewModel? GetById(int id);
        int Create(TInputModel entity);
        void Update(int id, TInputModel entity);
        void Delete(int id);
        TEntityModel GetByDbId(int id);
    }
}
