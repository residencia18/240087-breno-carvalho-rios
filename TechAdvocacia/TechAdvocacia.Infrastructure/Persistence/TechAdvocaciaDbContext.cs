using Microsoft.EntityFrameworkCore;

namespace TechAdvocacia.Infrastructure.Persistence;
public class TechAdvocaciaDbContext  : DbContext
{
    public TechAdvocaciaDbContext(DbContextOptions<TechAdvocaciaDbContext> dbContextOptions) : base(dbContextOptions){}

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TechAdvocaciaDbContext).Assembly);
    }
}
