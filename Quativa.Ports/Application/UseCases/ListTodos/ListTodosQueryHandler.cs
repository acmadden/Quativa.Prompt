using MediatR;
using Quativa.Ports.Application.ReadModels;
using Quativa.Ports.Persistence.Queries;

namespace Quativa.Ports.Application.UseCases.ListTodos;

public sealed class ListTodosQueryHandler : IRequestHandler<ListTodosQuery, List<TodoReadModel>>
{
    private readonly ITodoQueryRepository _repository;

    public ListTodosQueryHandler(ITodoQueryRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<TodoReadModel>> Handle(ListTodosQuery _, CancellationToken cancellationToken)
    {
        return await _repository.ListAsync();
    }
}