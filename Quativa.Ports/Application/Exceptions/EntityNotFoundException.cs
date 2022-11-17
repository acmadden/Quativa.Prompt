namespace Quativa.Ports.Application.Exceptions;

[Serializable]
public sealed class EntityNotFoundException : Exception
{
    public EntityNotFoundException(Guid id) : base($"Entity with id '{id}' was not found.") { }
    public EntityNotFoundException(string property) : base($"Entity with property '{property}' was not found.") { }
}