using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrdemDeServico.Domain.Entities;

namespace OrdemDeServico.Infra.Persistence.Configurations;

public class OrdemServicoConfigurations : IEntityTypeConfiguration<OrdemServico>
{
    public void Configure(EntityTypeBuilder<OrdemServico> builder)
    {
        builder.ToTable("OrdemServico").HasKey(od => od.OrdemServicoId);

        builder.HasOne(od => od.Cliente).WithMany(cli => cli.OrdemServico).HasForeignKey(od => od.ClienteId);
        builder.HasOne(od => od.PrestadorDeServico).WithMany(ps => ps.OrdemServico).HasForeignKey(od => od.PrestadorDeServicoId);
    }
}
