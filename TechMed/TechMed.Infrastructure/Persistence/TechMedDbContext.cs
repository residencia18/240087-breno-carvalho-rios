using Microsoft.EntityFrameworkCore;
using TechMed.Domain.Entities;

namespace TechMed.Infrastructure.Persistence;
public class TechMedDbContext : DbContext
{
    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Medico> Medicos { get; set; }
    public DbSet<Atendimento> Atendimentos { get; set; }
    public DbSet<Exame> Exames { get; set; }

    public TechMedDbContext(DbContextOptions<TechMedDbContext> dbContextOptions) : base(dbContextOptions)
   {

   }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      base.OnModelCreating(modelBuilder);

      modelBuilder.ApplyConfigurationsFromAssembly(typeof(TechMedDbContext).Assembly);
   }
}