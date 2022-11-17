using Microsoft.EntityFrameworkCore;
using Quativa.Domain;
using Quativa.Ports.Persistence.Commands;

namespace Quativa.Adapters.SqlServer.Repositories.Commands;

internal sealed class TodoStatusCommandRepository : ITodoStatusCommandRepository
{
    private readonly ApplicationDbContext _context;

    public TodoStatusCommandRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<TodoStatus>> LoadAsync()
    {
        return await _context.TodoStatuses.ToListAsync();
    }
}