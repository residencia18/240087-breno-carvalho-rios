using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Domain.Interfaces;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<T> Create(T entity);
    Task<T> Update(T entity);
    Task<T> Delete(T entity);
    Task<T> Delete(int id);
}
