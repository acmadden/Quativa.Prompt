using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Quativa.Adapters.SqlServer.DependencyInjection;

public static class ApplicationBuilderExtension
{
    public static IApplicationBuilder UseMigrations(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        context?.Database.Migrate();
        return app;
    }
}