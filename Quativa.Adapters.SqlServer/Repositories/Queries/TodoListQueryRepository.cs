using Microsoft.EntityFrameworkCore;
using Quativa.Ports.Application.ReadModels;
using Quativa.Ports.Persistence.Queries;

namespace Quativa.Adapters.SqlServer.Repositories.Queries;

internal sealed class TodoListQueryRepository : ITodoListQueryRepository
{
    private readonly ApplicationDbContext _context;

    public TodoListQueryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TodoListReadModel> FetchSingleAsync(Guid id)
    {
        var list = await _context.TodoLists.FindAsync(id);
        if (list is null)
        {
            throw new NullReferenceException();
        }
        return new TodoListReadModel
        {
            TodoListId = list.Id,
            Label = list.Label,
            Todos = new List<TodoReadModel>()
        };
    }

    public async Task<TodoListReadModel?> FetchDetailedSingleAsync(Guid id)
    {
        var list = await _context.TodoLists
            .AsNoTracking()
            .Include(x => x.Todos)
            .ThenInclude(x => x.Status)
            .FirstOrDefaultAsync(x => x.Id == id);
        if (list is null)
        {
            return null;
        }
        return new TodoListReadModel
        {
            TodoListId = list.Id,
            Label = list.Label,
            Todos = list.Todos.Select(todo => new TodoReadModel
            {
                TodoId = todo.Id,
                Label = todo.Label,
                Status = todo.Status?.DisplayName
            }).ToList()
        };
    }

    public async Task<List<TodoListReadModel>> ListAsync()
    {
        var lists = await _context.TodoLists
            .AsNoTracking()
            .Include(x => x.Todos)
            .ThenInclude(x => x.Status)
            .ToListAsync();
        return lists.Select(list => new TodoListReadModel
        {
            TodoListId = list.Id,
            Label = list.Label,
            Todos = list.Todos.Select(todo => new TodoReadModel
            {
                TodoId = todo.Id,
                Label = todo.Label,
                Status = todo.Status?.DisplayName
            }).ToList()
        }).ToList();
    }
}