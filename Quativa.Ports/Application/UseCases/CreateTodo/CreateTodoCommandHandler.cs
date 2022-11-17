using MediatR;
using Quativa.Domain;
using Quativa.Ports.Application.ReadModels;
using Quativa.Ports.Persistence.Commands;
using Quativa.Ports.Persistence.Queries;

namespace Quativa.Ports.Application.UseCases.CreateTodo;

public sealed class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, TodoReadModel>
{
    private readonly ITodoCommandRepository _todos;
    private readonly ITodoStatusCommandRepository _statuses;
    private readonly ITodoQueryRepository _reader;

    public CreateTodoCommandHandler(ITodoCommandRepository todos, ITodoStatusCommandRepository statuses, ITodoQueryRepository reader)
    {
        _todos = todos;
        _statuses = statuses;
        _reader = reader;
    }

    public async Task<TodoReadModel> Handle(CreateTodoCommand command, CancellationToken cancellationToken)
    {
        var statuses = await _statuses.LoadAsync();
        var @default = statuses.FirstOrDefault(status => status.Default);
        if (@default is null)
        {
            throw new InvalidOperationException();
        }
        var todo = new Todo(command.TodoListId, @default.Id, command.Label);
        todo = await _todos.CreateAsync(todo);
        return await _reader.FetchSingleAsync(todo.Id);
    }
}