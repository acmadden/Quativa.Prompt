namespace Quativa.Ports.Application.ReadModels;

public sealed class TodoListReadModel
{
    public Guid TodoListId { get; set; }
    public string? Label { get; set; }
    public List<TodoReadModel>? Todos { get; set; }
}