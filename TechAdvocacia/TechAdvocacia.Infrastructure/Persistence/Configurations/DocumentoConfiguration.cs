using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechAdvocacia.Core.Entities;

namespace TechAdvocacia.Infrastructure.Persistence.Configurations;
public class DocumentoConfigurations
{
    public void Configure(EntityTypeBuilder<Documento> builder)
    {
        builder.ToTable("documentos").HasKey(d => d.DocumentoId);
        builder.HasOne(d => d.CasoJuridico).WithMany(cj => cj.Documentos).HasForeignKey(d => d.CasoJuridicoId);
    }
}
