using CA.Todos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.Todos.Infrastructure.Persistence.Configurations
{
    internal class TodoListConfiguration : IEntityTypeConfiguration<TodoList>
    {
        public void Configure(EntityTypeBuilder<TodoList> builder)
        {
            builder.Property(_ => _.Title)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.OwnsOne(_ => _.Color);
        }
    }
}
