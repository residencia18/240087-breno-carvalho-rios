using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrdemDeServico.Domain.Entities;

namespace OrdemDeServico.Infra.Persistence.Configurations;

public class ServicoOrdemDeServicoConfigurations : IEntityTypeConfiguration<ServicoOrdemServico>
{
    public void Configure(EntityTypeBuilder<ServicoOrdemServico> builder)
    {
        builder.ToTable("ServicoOrdemServico").HasKey(s => s.ServicoOrdemServicoId);

        builder.HasOne(sos => sos.Endereco).WithOne(e => e.ServicoOrdemServico).HasForeignKey<ServicoOrdemServico>(sos => sos.EnderecoId);
        builder.HasOne(sos => sos.Servico).WithMany(s => s.ServicoOrdemServico).HasForeignKey(sos => sos.ServicoId);
        builder.HasOne(sos => sos.OrdemServico).WithMany(s => s.ServicoOrdemServico).HasForeignKey(sos => sos.OrdemServicoId);
    }
}
