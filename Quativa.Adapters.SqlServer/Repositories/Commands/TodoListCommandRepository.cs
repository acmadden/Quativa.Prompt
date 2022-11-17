using Quativa.Domain;
using Quativa.Ports.Persistence.Commands;

namespace Quativa.Adapters.SqlServer.Repositories.Commands;

internal sealed class TodoListCommandRepository : ITodoListCommandRepository
{
    private readonly ApplicationDbContext _context;

    public TodoListCommandRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TodoList> CreateAsync(TodoList list)
    {
        await _context.AddAsync(list);
        await _context.SaveChangesAsync();
        return list;
    }
}