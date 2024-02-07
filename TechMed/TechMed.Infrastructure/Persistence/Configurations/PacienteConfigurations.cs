using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechMed.Domain.Entities;

namespace TechMed.Infrastructure.Persistence.Configurations;
public class PacienteConfigurations : IEntityTypeConfiguration<Paciente>
{
        public void Configure(EntityTypeBuilder<Paciente> builder)
    {
        builder.HasKey(p => p.PacienteId);
    }
}