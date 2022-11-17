using Microsoft.EntityFrameworkCore;
using Quativa.Domain;

namespace Quativa.Adapters.SqlServer.EntityTypeConfigurations;

internal sealed class TodoListEntityTypeConfiguration : IEntityTypeConfiguration<TodoList>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TodoList> builder)
    {
        builder.Property(x => x.Id).HasColumnName("TodoListId");
        builder.Property(x => x.Label).IsRequired();
        builder.HasMany(x => x.Todos).WithOne().HasForeignKey(nameof(Todo.TodoListId));
    }
}