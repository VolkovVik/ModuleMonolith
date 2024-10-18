namespace ModuleMonolith.Modules.Codes.Domain.Abstractions;

public interface IDomainEvent
{
    Guid Id { get; }

    DateTime OccurredOnUtc { get; }
}
