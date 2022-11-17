namespace Quativa.Domain;

public sealed class TodoStatus
{
    public Guid Id { get; private set; }
    public string DisplayName { get; }
    public bool Default { get; }

    public TodoStatus(string displayName, bool @default)
    {
        if (string.IsNullOrWhiteSpace(displayName))
        {
            throw new ArgumentException();
        }
        DisplayName = displayName;
        Default = @default;
    }
}