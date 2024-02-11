using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrdemDeServico.Domain.Entities;

namespace OrdemDeServico.Infra.Persistence.Configurations;

public class PagamentoConfigurations : IEntityTypeConfiguration<Pagamento>
{
    public void Configure(EntityTypeBuilder<Pagamento> builder)
    {
        builder.ToTable("Pagamento").HasKey(pa => pa.PagamentoId);
        builder.HasOne(pa => pa.OrdemServico).WithMany(e => e.Pagamentos).HasForeignKey(pa => pa.OrdemServicoId);
    }
}
