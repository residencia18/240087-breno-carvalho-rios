using Microsoft.EntityFrameworkCore;
using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Infrastructure.Context;

public class ResTIConnectDbContext : DbContext
{
    public DbSet<Log> Logs { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Perfis> Perfis { get; set; }
    public DbSet<Sistema> Sistemas { get; set; }
    public DbSet<User> Usuarios { get; set; }
    public DbSet<Evento> Eventos { get; set; }

    public ResTIConnectDbContext(DbContextOptions<ResTIConnectDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ResTIConnectDbContext).Assembly);
    }
}
