using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Infrastructure;

public class EnderecoConfigurations : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.ToTable("enderecos").HasKey(e => e.EnderecoId);

        builder.HasOne(e => e.Usuario).WithOne(u => u.Endereco).HasForeignKey<Endereco>(e => e.UsuarioId);
    }
}
