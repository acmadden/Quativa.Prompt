using MediatR;
using Quativa.Ports.Application.Exceptions;
using Quativa.Ports.Application.ReadModels;
using Quativa.Ports.Persistence.Queries;

namespace Quativa.Ports.Application.UseCases.FetchSingleTodoList;

public sealed class FetchSingleTodoListQueryHandler : IRequestHandler<FetchSingleTodoListQuery, TodoListReadModel>
{
    private readonly ITodoListQueryRepository _repository;

    public FetchSingleTodoListQueryHandler(ITodoListQueryRepository repository)
    {
        _repository = repository;
    }
    public async Task<TodoListReadModel> Handle(FetchSingleTodoListQuery query, CancellationToken cancellationToken)
    {
        var list = await _repository.FetchDetailedSingleAsync(query.TodoListId);
        if (list is null)
        {
            throw new EntityNotFoundException(query.TodoListId);
        }
        return list;
    }
}