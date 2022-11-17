using MediatR;

namespace Quativa.Ports.Application.UseCases.DeleteTodo;

public sealed class DeleteTodoCommand : IRequest
{
    public Guid TodoId { get; }

    public DeleteTodoCommand(Guid todoId)
    {
        TodoId = todoId;
    }
}