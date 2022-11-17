namespace Quativa.Domain;

public sealed class TodoList
{
    public Guid Id { get; private set; }
    public string Label { get; private set; }
    public List<Todo> Todos { get; private set; }

    public TodoList(string label)
    {
        if (string.IsNullOrWhiteSpace(label))
        {
            throw new ArgumentException();
        }
        Label = label;
        Todos = new List<Todo>();
    }
}