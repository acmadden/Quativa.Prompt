namespace Quativa.Ports.Application.ReadModels;

public sealed class TodoReadModel
{
    public Guid TodoId { get; set; }
    public string? Label { get; set; }
    public string? Status { get; set; }
}