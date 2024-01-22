using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Domain.Interfaces;

public interface ILog: IBaseRepository<Log>
{
   Task<Log> GetById(int logId);
}

