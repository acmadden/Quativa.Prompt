using Quativa.Domain;

namespace Quativa.Ports.Persistence.Commands;

public interface ITodoCommandRepository
{
    Task<Todo?> LoadAsync(Guid id);
    Task<Todo> CreateAsync(Todo todo);
    Task<Todo> UpdateAsync(Todo todo);
    Task RemoveAsync(Todo todo);
}