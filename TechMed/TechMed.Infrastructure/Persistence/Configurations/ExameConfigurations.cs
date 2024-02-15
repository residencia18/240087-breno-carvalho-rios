using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechMed.Domain.Entities;

namespace TechMed.Infrastructure.Persistence.Configurations;
public class ExameConfigurations : IEntityTypeConfiguration<Exame>
{
    public void Configure(EntityTypeBuilder<Exame> builder)
    {
        builder.HasKey(e => e.ExameId);

        builder.HasOne(e => e.Atendimento)
        .WithMany(a => a.Exames)
        .HasForeignKey(e => e.AtendimentoId);
    }
}
