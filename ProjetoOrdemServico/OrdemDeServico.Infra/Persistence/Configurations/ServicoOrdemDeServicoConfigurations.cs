using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrdemDeServico.Domain.Entities;

namespace OrdemDeServico.Infra.Persistence.Configurations;

public class ServicoOrdemDeServicoConfigurations : IEntityTypeConfiguration<ServicoOrdemDeServico>
{
    public void Configure(EntityTypeBuilder<ServicoOrdemDeServico> builder)
    {
        builder.ToTable("ServicoOrdemDeServico").HasKey(s => s.ServicoOrdemDeServicoId);

        builder.HasOne(so => so.Endereco).WithOne(e => e.ServicoOrdemDeServico).HasForeignKey<ServicoOrdemDeServico>(so => so.EnderecoId);
        builder.HasOne(so => so.Servico).WithMany(s => s.ServicoOrdemDeServico).HasForeignKey(s => s.ServicoId);
        builder.HasOne(so => so.OrdemServico).WithMany(s => s.ServicoOrdemDeServico).HasForeignKey(os => os.OrdemDeServicoId);
    }
}
