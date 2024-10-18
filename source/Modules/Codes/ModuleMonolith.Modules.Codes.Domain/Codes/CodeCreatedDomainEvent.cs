using ModuleMonolith.Modules.Codes.Domain.Abstractions;

namespace ModuleMonolith.Modules.Codes.Domain.Codes;

public sealed class CodeCreatedDomainEvent(Guid codeId) : DomainEvent
{
    public Guid CodeId { get; init; } = codeId;
}
