
using Microsoft.EntityFrameworkCore;
using ResTIConnect.Domain.Entities;
namespace ResTIConnect.Infrastructure.Context
{
    public class ResTIConnectContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Perfis> Perfis { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Sistema> Sistemas { get; set; }

        public ResTIConnectContext(DbContextOptions<ResTIConnectContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ResTIConnectContext).Assembly);
        }
    }
}
