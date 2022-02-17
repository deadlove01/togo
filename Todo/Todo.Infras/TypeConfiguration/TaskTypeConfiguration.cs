using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Domains.Entities;

namespace Todo.Infras.TypeConfiguration
{
    internal sealed class TaskTypeConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.ToTable(nameof(Task) + "s");

            builder.HasIndex(p => p.UserId);
        }
    }
}