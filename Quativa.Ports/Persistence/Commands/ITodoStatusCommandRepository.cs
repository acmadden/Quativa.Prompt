using Quativa.Domain;

namespace Quativa.Ports.Persistence.Commands;

public interface ITodoStatusCommandRepository
{
    Task<List<TodoStatus>> LoadAsync();
}