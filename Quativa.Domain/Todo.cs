namespace Quativa.Domain;

public sealed class Todo
{
    public Guid Id { get; private set; }
    public Guid? TodoListId { get; private set; }
    public Guid TodoStatusId { get; private set; }
    public TodoStatus? Status { get; private set; }
    public string Label { get; private set; }

    public Todo(Guid? todoListId, Guid todoStatusId, string label)
    {
        if (todoStatusId == Guid.Empty)
        {
            throw new ArgumentException();
        }
        else if (string.IsNullOrWhiteSpace(label))
        {
            throw new ArgumentException();
        }
        TodoListId = todoListId;
        TodoStatusId = todoStatusId;
        Label = label;
    }

    public void Assign(Guid? todoListId)
    {
        TodoListId = todoListId;
    }

    public void Rename(string label)
    {
        if (string.IsNullOrWhiteSpace(label))
        {
            throw new ArgumentException();
        }
        Label = label;
    }

    public void Update(TodoStatus status)
    {
        if (status is null)
        {
            throw new ArgumentNullException();
        }
        TodoStatusId = status.Id;
        Status = status;
    }
}