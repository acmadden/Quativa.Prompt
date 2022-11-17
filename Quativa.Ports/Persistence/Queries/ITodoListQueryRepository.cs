using Quativa.Ports.Application.ReadModels;

namespace Quativa.Ports.Persistence.Queries;

public interface ITodoListQueryRepository
{
    Task<TodoListReadModel> FetchSingleAsync(Guid id);
    Task<TodoListReadModel?> FetchDetailedSingleAsync(Guid id);
    Task<List<TodoListReadModel>> ListAsync();
}