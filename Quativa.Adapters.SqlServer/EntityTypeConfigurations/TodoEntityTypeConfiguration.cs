using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quativa.Domain;

namespace Quativa.Adapters.SqlServer.EntityTypeConfigurations;

internal sealed class TodoEntityTypeConfiguration : IEntityTypeConfiguration<Todo>
{
    public void Configure(EntityTypeBuilder<Todo> builder)
    {
        builder.Property(x => x.Id).HasColumnName("TodoId");
        builder.Property(x => x.Label).IsRequired();
        builder.HasOne(x => x.Status).WithMany().HasForeignKey(nameof(Todo.TodoStatusId));
    }
}