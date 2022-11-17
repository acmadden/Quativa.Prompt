using Quativa.Ports.Application.ReadModels;

namespace Quativa.Ports.Persistence.Queries;

public interface ITodoQueryRepository
{
    Task<TodoReadModel> FetchSingleAsync(Guid id);
    Task<List<TodoReadModel>> ListAsync();
}