using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quativa.Domain;

namespace Quativa.Adapters.SqlServer.EntityTypeConfigurations;

internal sealed class TodoStatusEntityTypeConfiguration : IEntityTypeConfiguration<TodoStatus>
{
    public void Configure(EntityTypeBuilder<TodoStatus> builder)
    {
        builder.Property(x => x.Id).HasColumnName("TodoStatusId");
        builder.Property(x => x.DisplayName).IsRequired();
        builder.Property(x => x.Default);
    }
}