using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Quativa.Adapters.SqlServer.Repositories.Commands;
using Quativa.Adapters.SqlServer.Repositories.Queries;
using Quativa.Ports.Persistence.Commands;
using Quativa.Ports.Persistence.Queries;

namespace Quativa.Adapters.SqlServer.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDataRepositories(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
        services.AddTransient<ITodoListCommandRepository, TodoListCommandRepository>();
        services.AddTransient<ITodoStatusCommandRepository, TodoStatusCommandRepository>();
        services.AddTransient<ITodoListQueryRepository, TodoListQueryRepository>();
        services.AddTransient<ITodoCommandRepository, TodoCommandRepository>();
        services.AddTransient<ITodoQueryRepository, TodoQueryRepository>();
        return services;
    }
}