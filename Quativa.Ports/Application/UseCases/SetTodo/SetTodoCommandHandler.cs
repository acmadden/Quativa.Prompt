using MediatR;
using Quativa.Ports.Application.Exceptions;
using Quativa.Ports.Application.ReadModels;
using Quativa.Ports.Persistence.Commands;
using Quativa.Ports.Persistence.Queries;

namespace Quativa.Ports.Application.UseCases.SetTodo;

public sealed class SetTodoCommandHandler : IRequestHandler<SetTodoCommand, TodoReadModel>
{
    private readonly ITodoCommandRepository _todos;
    private readonly ITodoStatusCommandRepository _statuses;
    private readonly ITodoQueryRepository _reader;

    public SetTodoCommandHandler(ITodoCommandRepository todos, ITodoStatusCommandRepository statuses, ITodoQueryRepository reader)
    {
        _todos = todos;
        _statuses = statuses;
        _reader = reader;
    }

    public async Task<TodoReadModel> Handle(SetTodoCommand command, CancellationToken cancellationToken)
    {
        var todo = await _todos.LoadAsync(command.TodoId);
        if (todo is null)
        {
            throw new EntityNotFoundException(command.TodoId);
        }
        var statuses = await _statuses.LoadAsync();
        var status = statuses.FirstOrDefault(status => status.DisplayName == command.Status);
        if (status is null)
        {
            throw new EntityNotFoundException(command.Status);
        }
        todo.Assign(command.TodoListId);
        todo.Rename(command.Label);
        todo.Update(status);
        await _todos.UpdateAsync(todo);
        return await _reader.FetchSingleAsync(todo.Id);
    }
}