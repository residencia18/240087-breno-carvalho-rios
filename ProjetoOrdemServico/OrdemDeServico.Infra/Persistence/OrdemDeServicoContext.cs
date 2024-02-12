using Microsoft.EntityFrameworkCore;
using OrdemDeServico.Domain.Entities;

namespace ResTIConnect.Infrastructure.Persistence;

public class OrdemDeServicoContext : DbContext
{

    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<ServicoOrdemServico> ServicosOrdensServico { get; set; }
    public DbSet<PrestadorDeServico> PrestadoresDeServico { get; set; }
    public DbSet<Pagamento> Pagamentos { get; set; }
    public DbSet<OrdemServico> OrdensServico { get; set; }
    public DbSet<Servico> Servicos { get; set; }

    public OrdemDeServicoContext(DbContextOptions<OrdemDeServicoContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrdemDeServicoContext).Assembly);
    }
}
