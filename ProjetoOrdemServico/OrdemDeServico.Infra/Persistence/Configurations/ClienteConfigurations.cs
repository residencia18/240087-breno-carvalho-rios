using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrdemDeServico.Domain.Entities;

namespace OrdemDeServico.Infra.Persistence.Configurations;

public class ClienteConfigurations : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("Cliente").HasKey(c => c.ClienteId);

        builder.HasOne(c => c.Usuario).WithOne(u => u.Cliente).HasForeignKey<Cliente>(c => c.UsuarioId);
        builder.HasOne(c => c.Endereco).WithOne(e => e.Cliente).HasForeignKey<Cliente>(c => c.EnderecoId);
    }
}
