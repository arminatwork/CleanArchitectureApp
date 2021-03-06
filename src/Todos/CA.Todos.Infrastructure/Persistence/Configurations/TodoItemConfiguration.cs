using CA.Todos.Domain;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.Todos.Infrastructure.Persistence.Configurations;

internal class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
{
    public void Configure(EntityTypeBuilder<TodoItem> builder)
    {
        builder.Ignore(_ => _.DomainEvents);

        builder.Property(_ => _.Title)
            .HasMaxLength(200)
            .IsRequired();
    }
}
