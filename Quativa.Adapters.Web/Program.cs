using MediatR;
using Quativa.Adapters.SqlServer.DependencyInjection;
using Quativa.Ports.Application.UseCases.CreateTodoList;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMediatR(typeof(CreateTodoListCommand));
builder.Services.AddDataRepositories(builder.Configuration.GetConnectionString("SqlServer"));
builder.Services.AddControllers();

var app = builder.Build();
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());
app.UseMigrations();
app.Run();
