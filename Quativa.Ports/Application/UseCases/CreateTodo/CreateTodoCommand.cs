using MediatR;
using Quativa.Ports.Application.ReadModels;

namespace Quativa.Ports.Application.UseCases.CreateTodo;

public sealed class CreateTodoCommand : IRequest<TodoReadModel>
{
    public Guid? TodoListId { get; }
    public string Label { get; }

    public CreateTodoCommand(Guid? todoListId, string label)
    {
        TodoListId = todoListId;
        Label = label;
    }
}