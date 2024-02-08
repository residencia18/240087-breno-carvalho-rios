using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechMed.Domain.Entities;

namespace TechMed.Infrastructure.Persistence.Configurations;
public class MedicoConfigurations : IEntityTypeConfiguration<Medico>
{
    public void Configure(EntityTypeBuilder<Medico> builder)
    {
        builder.HasKey(m => m.MedicoId);
    }
}