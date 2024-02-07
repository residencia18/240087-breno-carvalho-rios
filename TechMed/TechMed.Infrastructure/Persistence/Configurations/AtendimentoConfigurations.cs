using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

using TechMed.Domain.Entities;

namespace TechMed.Infrastructure.Persistence.Configurations;
public class AtendimentoConfigurations : IEntityTypeConfiguration<Atendimento>
{
    public void Configure(EntityTypeBuilder<Atendimento> builder)
    {
        builder.HasKey(a => a.AtendimentoId);

        builder.HasOne(a => a.Medico)
        .WithMany(m => m.Atendimentos)
        .HasForeignKey(a => a.MedicoId);

        builder.HasOne(a => a.Paciente)
        .WithMany(p => p.Atendimentos)
        .HasForeignKey(a => a.PacienteId);

        builder.HasMany(a => a.Exames)
        .WithOne(e => e.Atendimento)
        .HasForeignKey(a => a.ExameId);
    }
}