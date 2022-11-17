using MediatR;
using Quativa.Ports.Application.ReadModels;

namespace Quativa.Ports.Application.UseCases.ListTodoLists;

public sealed class ListTodoListsQuery : IRequest<List<TodoListReadModel>> { }