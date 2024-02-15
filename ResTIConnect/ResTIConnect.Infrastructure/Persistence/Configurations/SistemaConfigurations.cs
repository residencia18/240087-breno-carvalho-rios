using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Infrastructure;

public class SistemaConfiguration : IEntityTypeConfiguration<Sistema>
{
    public void Configure(EntityTypeBuilder<Sistema> builder)
    {
        builder.ToTable("Sistemas").HasKey(m => m.SistemaId);

        builder.HasMany(s => s.Usuarios).WithMany(u => u.Sistemas);

        //builder.HasMany(s => s.Eventos).WithMany(ev => ev.Sistemas);
    }
}
