using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Infrastructure
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users").HasKey(u => u.UserId);

            //builder.HasMany(u => u.Perfis).WithOne(p => p.User); 
            builder.HasMany(u => u.Sistemas).WithMany(s => s.Users);
        }
    }
}
