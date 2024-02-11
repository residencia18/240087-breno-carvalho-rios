using TechMed.Infrastructure.Persistence;

namespace TechMed.Application.Services;

public class BaseService
{
    protected readonly TechMedDbContext _context;
    protected BaseService(TechMedDbContext context)
    {
        _context = context;
    }
}
