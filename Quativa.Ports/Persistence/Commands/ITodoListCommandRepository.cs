using Quativa.Domain;

namespace Quativa.Ports.Persistence.Commands;

public interface ITodoListCommandRepository
{
    Task<TodoList> CreateAsync(TodoList list);
}