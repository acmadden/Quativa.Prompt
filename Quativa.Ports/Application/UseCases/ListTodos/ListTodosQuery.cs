using MediatR;
using Quativa.Ports.Application.ReadModels;

namespace Quativa.Ports.Application.UseCases.ListTodos;

public sealed class ListTodosQuery : IRequest<List<TodoReadModel>> { }