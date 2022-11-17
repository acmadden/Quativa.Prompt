using Microsoft.EntityFrameworkCore;
using Quativa.Adapters.SqlServer.EntityTypeConfigurations;
using Quativa.Domain;

namespace Quativa.Adapters.SqlServer;

internal sealed class ApplicationDbContext : DbContext
{
    public DbSet<TodoList> TodoLists => Set<TodoList>();
    public DbSet<TodoStatus> TodoStatuses => Set<TodoStatus>();
    public DbSet<Todo> Todos => Set<Todo>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TodoListEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new TodoStatusEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new TodoEntityTypeConfiguration());
    }
}