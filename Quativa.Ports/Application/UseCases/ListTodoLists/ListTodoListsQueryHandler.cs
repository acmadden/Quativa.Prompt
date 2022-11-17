using MediatR;
using Quativa.Ports.Application.ReadModels;
using Quativa.Ports.Persistence.Queries;

namespace Quativa.Ports.Application.UseCases.ListTodoLists;

public sealed class ListTodoListsQueryHandler : IRequestHandler<ListTodoListsQuery, List<TodoListReadModel>>
{
    private readonly ITodoListQueryRepository _repository;

    public ListTodoListsQueryHandler(ITodoListQueryRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<TodoListReadModel>> Handle(ListTodoListsQuery query, CancellationToken cancellationToken)
    {
        return await _repository.ListAsync();
    }
}