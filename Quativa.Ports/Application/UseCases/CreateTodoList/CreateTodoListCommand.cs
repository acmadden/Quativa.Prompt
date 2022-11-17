using MediatR;
using Quativa.Ports.Application.ReadModels;

namespace Quativa.Ports.Application.UseCases.CreateTodoList;

public sealed class CreateTodoListCommand : IRequest<TodoListReadModel>
{
    public string Label { get; }

    public CreateTodoListCommand(string label)
    {
        Label = label;
    }
}