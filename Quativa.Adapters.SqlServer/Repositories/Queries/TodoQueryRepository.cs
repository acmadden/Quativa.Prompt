using Microsoft.EntityFrameworkCore;
using Quativa.Ports.Application.ReadModels;
using Quativa.Ports.Persistence.Queries;

namespace Quativa.Adapters.SqlServer.Repositories.Queries;

internal sealed class TodoQueryRepository : ITodoQueryRepository
{
    private readonly ApplicationDbContext _context;

    public TodoQueryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TodoReadModel> FetchSingleAsync(Guid id)
    {
        var todo = await _context.Todos.FindAsync(id);
        if (todo is null)
        {
            throw new NullReferenceException();
        }
        return new TodoReadModel
        {
            TodoId = todo.Id,
            Label = todo.Label,
            Status = todo.Status?.DisplayName
        };
    }

    public async Task<List<TodoReadModel>> ListAsync()
    {
        var todos = await _context.Todos
            .AsNoTracking()
            .Include(x => x.Status)
            .ToListAsync();
        return todos.Select(todo => new TodoReadModel
        {
            TodoId = todo.Id,
            Label = todo.Label,
            Status = todo.Status?.DisplayName
        }).ToList();
    }
}