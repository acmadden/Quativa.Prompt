using Quativa.Domain;
using Quativa.Ports.Persistence.Commands;

namespace Quativa.Adapters.SqlServer.Repositories.Commands;

internal sealed class TodoCommandRepository : ITodoCommandRepository
{
    private readonly ApplicationDbContext _context;

    public TodoCommandRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Todo?> LoadAsync(Guid id)
    {
        return await _context.Todos.FindAsync(id);
    }

    public async Task<Todo> CreateAsync(Todo todo)
    {
        await _context.AddAsync(todo);
        await _context.SaveChangesAsync();
        return todo;
    }

    public async Task<Todo> UpdateAsync(Todo todo)
    {
        _context.Update(todo);
        await _context.SaveChangesAsync();
        return todo;
    }

    public async Task RemoveAsync(Todo todo)
    {
        _context.Remove(todo);
        await _context.SaveChangesAsync();
    }
}