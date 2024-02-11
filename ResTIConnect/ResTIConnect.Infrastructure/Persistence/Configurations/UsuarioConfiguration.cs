using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Infrastructure;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("usuarios").HasKey(u => u.UsuarioId);

        builder.HasMany(u => u.Perfil).WithOne(p => p.Usuario);
        builder.HasMany(u => u.Sistemas).WithMany(s => s.Usuarios);
    }
}
