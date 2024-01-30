using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechAdvocacia.Core.Entities;

namespace TechAdvocacia.Infrastructure.Persistence.Configurations;
public class CasoJuridicoConfigurations
{
    public void Configure(EntityTypeBuilder<CasoJuridico> builder)
    {
        builder.ToTable("CasosJuridicos").HasKey(c => c.CasoJuridicoId);
        builder.HasOne(cj => cj.Advogado).WithMany(a => a.CasosJuridicos).HasForeignKey(cj => cj.AdvogadoId);
        builder.HasOne(cj => cj.Cliente).WithMany(c => c.CasosJuridicos).HasForeignKey(cj => cj.ClienteId);
    }
}
