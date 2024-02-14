using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Infrastructure;

public class PerfilConfiguration : IEntityTypeConfiguration<Perfis>
{
    public void Configure(EntityTypeBuilder<Perfis> builder)
    {
        builder.ToTable("perfis").HasKey(p => p.PerfilId);
    }
}
