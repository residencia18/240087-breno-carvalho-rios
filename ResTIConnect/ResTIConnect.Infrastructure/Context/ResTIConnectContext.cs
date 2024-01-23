using Microsoft.EntityFrameworkCore;
using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Infrastructure;

public class ResTIConnectContext : DbContext
{

    public DbSet<Log> Logs { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Perfil> Perfis { get; set; }
    public DbSet<Sistemas> Sistemas { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var connectionString = "server=localhost;user=root;password=12345;database=resticonnect";
        var serverVersion = ServerVersion.AutoDetect(connectionString);
        
        optionsBuilder.UseMySql(connectionString, serverVersion);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Log>().ToTable("Logs").HasKey(m => m.LogId);

        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Endereco>().ToTable("Enderecos").HasKey(m => m.EnderecoId);

        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Sistemas>().ToTable("Sistemas").HasKey(m => m.SistemaId);

       
    }
}