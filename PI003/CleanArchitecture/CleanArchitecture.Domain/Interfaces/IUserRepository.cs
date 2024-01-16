using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence.Repositories;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEmail(string email, CancellationToken cancellationToken);
    }
}
