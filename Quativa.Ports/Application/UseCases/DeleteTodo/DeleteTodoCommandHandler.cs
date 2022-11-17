using MediatR;
using Quativa.Ports.Application.Exceptions;
using Quativa.Ports.Persistence.Commands;

namespace Quativa.Ports.Application.UseCases.DeleteTodo;

public sealed class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand>
{
    private readonly ITodoCommandRepository _todos;

    public DeleteTodoCommandHandler(ITodoCommandRepository todos)
    {
        _todos = todos;
    }

    public async Task<Unit> Handle(DeleteTodoCommand command, CancellationToken cancellationToken)
    {
        var todo = await _todos.LoadAsync(command.TodoId);
        if (todo is null)
        {
            throw new EntityNotFoundException(command.TodoId);
        }
        await _todos.RemoveAsync(todo);
        return Unit.Value;
    }
}