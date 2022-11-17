using MediatR;
using Quativa.Ports.Application.ReadModels;

namespace Quativa.Ports.Application.UseCases.SetTodo;

public sealed class SetTodoCommand : IRequest<TodoReadModel>
{
    public Guid TodoId { get; set; }
    public Guid? TodoListId { get; }
    public string Label { get; }
    public string Status { get; }

    public SetTodoCommand(Guid? todoListId, string label, string status)
    {
        TodoListId = todoListId;
        Label = label;
        Status = status;
    }
}