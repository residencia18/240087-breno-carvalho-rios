using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechAdvocacia.Core.Entities;

namespace TechAdvocacia.Infrastructure.Persistence.Configurations;
public class AdvogadoConfigurations
{
    public void Configure(EntityTypeBuilder<Advogado> builder)
    {
        builder.ToTable("advogados").HasKey(a => a.AdvogadoId);
    }
}
