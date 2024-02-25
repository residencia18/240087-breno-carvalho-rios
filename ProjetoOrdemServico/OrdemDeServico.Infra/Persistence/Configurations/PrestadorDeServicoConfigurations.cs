using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrdemDeServico.Domain.Entities;

namespace OrdemDeServico.Infra.Persistence.Configurations;

public class PrestadorDeServicoConfigurations : IEntityTypeConfiguration<PrestadorDeServico>
{
    public void Configure(EntityTypeBuilder<PrestadorDeServico> builder)
    {
        builder.ToTable("PrestadorDeServico").HasKey(p => p.PrestadorDeServicoId);

        builder.HasOne(p => p.Usuario).WithOne(u => u.PrestadorDeServico).HasForeignKey<PrestadorDeServico>(p => p.UsuarioId);
        builder.HasOne(p => p.Endereco).WithOne(e => e.PrestadorDeServico).HasForeignKey<PrestadorDeServico>(p => p.EnderecoId);
    }
}
