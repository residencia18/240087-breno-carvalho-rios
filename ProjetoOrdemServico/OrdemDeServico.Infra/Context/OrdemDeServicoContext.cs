using Microsoft.EntityFrameworkCore;
using OrdemDeServico.Domain.Entities;

namespace ResTIConnect.Infrastructure;

public class OrdemDeServicoContext : DbContext
{
    
    public DbSet<Endereco> Endereco { get; set; }
    public DbSet<Cliente> Cliente { get; set; }
    public DbSet<ServicoOrdemDeServico> ServicoOrdemDeServico { get; set; }
    public DbSet<PrestadorDeServico> PrestadorDeServico { get; set;} 
    public DbSet<Pagamento> Pagamento { get; set;} 
    public DbSet<OrdemServico> OrdemServico { get; set;} 
    public DbSet<Servico> Servico { get; set;} 


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var connectionString = "server=localhost;user=dotnet;password=tic2023;database=OrdemDeServico";
        var serverVersion = ServerVersion.AutoDetect(connectionString);

        optionsBuilder.UseMySql(connectionString, serverVersion);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PrestadorDeServico>().ToTable("PrestadorDeServico").HasKey(p => p.PrestadorDeServicoId);
        modelBuilder.Entity<Endereco>().ToTable("Endereco").HasKey(e => e.EnderecoId);
        modelBuilder.Entity<Cliente>().ToTable("Cliente").HasKey(c => c.ClienteId);
        modelBuilder.Entity<ServicoOrdemDeServico>().ToTable("ServicoOrdemDeServico").HasKey(s => s.ServicoOrdemDeServicoId);
        modelBuilder.Entity<Pagamento>().ToTable("Pagamento").HasKey(pa => pa.PagamentoId);
        modelBuilder.Entity<OrdemServico>().ToTable("OrdemDeServico").HasKey(od => od.OrdemServicoId);
        modelBuilder.Entity<Servico>().ToTable("Servico").HasKey(s => s.ServicoId);
        

        modelBuilder.Entity<Cliente>()
            .HasOne(e => e.Endereco)
            .WithOne(e => e.Cliente)
            .HasForeignKey<Cliente>(c => c.EnderecoId);

        modelBuilder.Entity<PrestadorDeServico>()
            .HasOne(p => p.Endereco)
            .WithOne(e => e.PrestadorDeServico)
            .HasForeignKey<PrestadorDeServico>(p => p.EnderecoId);

        modelBuilder.Entity<ServicoOrdemDeServico>()
            .HasOne(so => so.Endereco)
            .WithOne(e => e.ServicoOrdemDeServico)
            .HasForeignKey<ServicoOrdemDeServico>(so => so.EnderecoId);
        
        modelBuilder.Entity<Pagamento>()
            .HasOne(pa => pa.OrdemServico)
            .WithMany(e => e.Pagamentos)
            .HasForeignKey(pa => pa.OrdemServicoId);

        modelBuilder.Entity<OrdemServico>()
            .HasOne(od => od.Cliente)
            .WithMany(cli => cli.OrdemServico)
            .HasForeignKey(od => od.ClienteId);

        modelBuilder.Entity<OrdemServico>()
            .HasOne(od => od.PrestadorDeServico)
            .WithMany(ps => ps.OrdemServico)
            .HasForeignKey(od => od.PrestadorId);
        
        modelBuilder.Entity<ServicoOrdemDeServico>()
            .HasOne(so => so.Servico)
            .WithMany(s => s.ServicoOrdemDeServico)
            .HasForeignKey(s => s.ServicoId);
        
        modelBuilder.Entity<ServicoOrdemDeServico>()
            .HasOne(so => so.OrdemServico)
            .WithMany(s => s.ServicoOrdemDeServico)
            .HasForeignKey(os => os.OrdemDeServicoId);
    }
}