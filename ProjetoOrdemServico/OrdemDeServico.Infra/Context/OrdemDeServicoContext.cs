using Microsoft.EntityFrameworkCore;
using OrdemDeServico.Domain.Entities;

namespace ResTIConnect.Infrastructure;

public class OrdemDeServicoContext : DbContext
{
    
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Ordem_De_Servico> Ordem_De_Servicos { get; set; }
    public DbSet<Servico_Ordem_De_Servico> Servico_Ordem_De_Servicos { get; set; }
    public DbSet<Prestador_De_Servico> Prestador_De_Servicos { get; set;} 


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var connectionString = "server=localhost;user=root;password=12345;database=OrdemDeServico";
        var serverVersion = ServerVersion.AutoDetect(connectionString);

        optionsBuilder.UseMySql(connectionString, serverVersion);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Prestador_De_Servico>().ToTable("Prestador_De_Servicos").HasKey(l => l.Prestador_De_ServicoId);
        modelBuilder.Entity<Endereco>().ToTable("Enderecos").HasKey(l => l.EnderecoId);

        modelBuilder.Entity<Ordem_De_Servico>()
                .HasOne(o => o.Endereco)
                .WithOne(e => e.Ordem_De_Servico)
                .HasForeignKey<Endereco>(e => e.Ordem_De_ServicoId);

        modelBuilder.Entity<Prestador_De_Servico>()
                .HasOne(p => p.Endereco)
                .WithOne(e => e.Prestador_De_Servico)
                .HasForeignKey<Endereco>(e => e.Prestador_De_ServicoId);

         modelBuilder.Entity<Endereco>()
                .HasOne(e => e.Servico_Ordem_De_Servico)
                .WithOne(so => so.Endereco)
                .HasForeignKey<Servico_Ordem_De_Servico>(so => so.EnderecoId);


        
    }
}