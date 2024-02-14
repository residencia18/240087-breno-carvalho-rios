using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Infrastructure;

public class UsuarioConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("usuarios").HasKey(u => u.UserId);

        builder.HasMany(u => u.Perfis).WithOne();
        builder.HasMany(u => u.Sistemas).WithMany(s => s.Usuarios);
    }
}
