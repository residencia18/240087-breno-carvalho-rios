using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Infrastructure;

public class PerfilConfigurations : IEntityTypeConfiguration<Perfil>
{
    public void Configure(EntityTypeBuilder<Perfil> builder)
    {
        builder.ToTable("perfis").HasKey(p => p.PerfilId);

        builder.HasOne(p => p.Usuario).WithMany(u => u.Perfis).HasForeignKey(p => p.UsuarioId);

    }
}
