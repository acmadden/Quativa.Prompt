using MediatR;
using Quativa.Ports.Application.ReadModels;

namespace Quativa.Ports.Application.UseCases.FetchSingleTodoList;

public sealed class FetchSingleTodoListQuery : IRequest<TodoListReadModel>
{
    public Guid TodoListId { get; }

    public FetchSingleTodoListQuery(Guid todoListId)
    {
        TodoListId = todoListId;
    }
}