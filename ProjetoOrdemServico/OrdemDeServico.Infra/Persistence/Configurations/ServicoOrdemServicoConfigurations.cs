using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrdemDeServico.Domain.Entities;

namespace OrdemDeServico.Infra.Persistence.Configurations;

public class ServicoOrdemDeServicoConfigurations : IEntityTypeConfiguration<ServicoOrdemServico>
{
    public void Configure(EntityTypeBuilder<ServicoOrdemServico> builder)
    {
        builder.ToTable("ServicoOrdemDeServico").HasKey(s => s.ServicoOrdemServicoId);

        builder.HasOne(so => so.Endereco).WithOne(e => e.ServicoOrdemServico).HasForeignKey<ServicoOrdemServico>(so => so.EnderecoId);
        builder.HasOne(so => so.Servico).WithMany(s => s.ServicoOrdemServico).HasForeignKey(s => s.ServicoId);
        builder.HasOne(so => so.OrdemServico).WithMany(s => s.ServicoOrdemServico).HasForeignKey(os => os.OrdemServicoId);
    }
}
