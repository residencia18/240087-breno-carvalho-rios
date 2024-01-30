using Microsoft.EntityFrameworkCore;
using TechAdvocacia.Core.Entities;

namespace TechAdvocacia.Infrastructure.Persistence;
public class TechAdvocaciaDbContext : DbContext
{
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Advogado> Advogados { get; set; }
    public DbSet<CasoJuridico> CasosJuridicos { get; set; }
    public DbSet<Documento> Documentos { get; set; }

    public TechAdvocaciaDbContext(DbContextOptions<TechAdvocaciaDbContext> dbContextOptions) : base(dbContextOptions){}

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TechAdvocaciaDbContext).Assembly);
    }
}
