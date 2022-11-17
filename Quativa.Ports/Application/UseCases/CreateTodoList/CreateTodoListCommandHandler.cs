using MediatR;
using Quativa.Domain;
using Quativa.Ports.Application.ReadModels;
using Quativa.Ports.Persistence.Commands;
using Quativa.Ports.Persistence.Queries;

namespace Quativa.Ports.Application.UseCases.CreateTodoList;

public sealed class CreateTodoListCommandHandler : IRequestHandler<CreateTodoListCommand, TodoListReadModel>
{
    private readonly ITodoListCommandRepository _lists;
    private readonly ITodoListQueryRepository _reader;

    public CreateTodoListCommandHandler(ITodoListCommandRepository lists, ITodoListQueryRepository reader)
    {
        _lists = lists;
        _reader = reader;
    }

    public async Task<TodoListReadModel> Handle(CreateTodoListCommand command, CancellationToken cancellationToken)
    {
        var list = new TodoList(command.Label);
        list = await _lists.CreateAsync(list);
        return await _reader.FetchSingleAsync(list.Id);
    }
}