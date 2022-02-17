using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Domains.Entities;

namespace Todo.Infras.TypeConfiguration
{
    internal sealed class UserTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User) + "s");

            builder.HasMany(p => p.Tasks)
                .WithOne();
            
        }
    }
}