using Microsoft.EntityFrameworkCore;
using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Infrastructure;

public class LogConfigurations : IEntityTypeConfiguration<Log>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Log> builder)
    {
        builder.ToTable("logs").HasKey(l => l.LogId);
    }
}
