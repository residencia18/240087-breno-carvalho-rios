using Microsoft.EntityFrameworkCore;
using OrdemDeServico.Domain.Entities;

namespace ResTIConnect.Infrastructure;

public class OrdemDeServicoContext : DbContext
{

    public DbSet<Endereco> Endereco { get; set; }
    public DbSet<Cliente> Cliente { get; set; }
    public DbSet<ServicoOrdemServico> ServicoOrdemServico { get; set; }
    public DbSet<PrestadorDeServico> PrestadorDeServico { get; set; }
    public DbSet<Pagamento> Pagamento { get; set; }
    public DbSet<OrdemServico> OrdemServico { get; set; }
    public DbSet<Servico> Servico { get; set; }

    public OrdemDeServicoContext(DbContextOptions<OrdemDeServicoContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrdemDeServicoContext).Assembly);
    }
}
