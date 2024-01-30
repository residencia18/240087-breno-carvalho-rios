using Microsoft.EntityFrameworkCore;
using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Infrastructure;

public class ResTIConnectContext : DbContext
{

    public DbSet<Log> Logs { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Perfil> Perfis { get; set; }
    public DbSet<Sistemas> Sistemas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Evento> Eventos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var connectionString = "server=localhost;user=root;password=root;database=resticonnect";
        var serverVersion = ServerVersion.AutoDetect(connectionString);

        optionsBuilder.UseMySql(connectionString, serverVersion);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Log>().ToTable("logs").HasKey(l => l.LogId);
        modelBuilder.Entity<Endereco>().ToTable("enderecos").HasKey(e => e.EnderecoId);
        modelBuilder.Entity<Perfil>().ToTable("perfis").HasKey(p => p.PerfilId);
        modelBuilder.Entity<Usuario>().ToTable("usuarios").HasKey(u => u.UsuarioId);
        modelBuilder.Entity<Evento>().ToTable("eventos").HasKey(ev => ev.EventoId);
        modelBuilder.Entity<Sistemas>().ToTable("Sistemas").HasKey(m => m.SistemaId);

        modelBuilder.Entity<Usuario>().HasMany(u => u.Perfil).WithOne(p => p.Usuario);
        modelBuilder.Entity<Usuario>().HasMany(u => u.Sistemas).WithMany(s => s.Usuarios);
        modelBuilder.Entity<Endereco>().HasOne(e => e.Usuario).WithOne(u => u.Endereco).HasForeignKey<Endereco>(e => e.UsuarioId);
        modelBuilder.Entity<Sistemas>().HasMany(s => s.Eventos).WithMany(ev => ev.Sistemas);
    }
}
