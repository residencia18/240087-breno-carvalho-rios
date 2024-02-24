using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MvcMovie.Models;

namespace MvcMovie.Data.Configurations;

public class MovieConfigurations : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.Navigation(m => m.Studio).AutoInclude();
        builder.Navigation(m => m.Artists).AutoInclude();

        builder.HasOne(m => m.Studio).WithMany(s => s.Movies).HasForeignKey(m => m.StudioId);
        builder.HasMany(m => m.Artists).WithMany(a => a.Movies);
    }
}
