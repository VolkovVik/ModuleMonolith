using ModuleMonolith.Common.Domain;

namespace ModuleMonolith.Modules.Codes.Domain.Codes.DomainEvents;

public sealed class CodePrintedDomainEvent(Guid codeId) : DomainEvent
{
    public Guid CodeId { get; init; } = codeId;
}
