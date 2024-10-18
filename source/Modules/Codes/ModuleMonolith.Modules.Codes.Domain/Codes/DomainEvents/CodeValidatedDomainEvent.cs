﻿using ModuleMonolith.Modules.Codes.Domain.Abstractions;

namespace ModuleMonolith.Modules.Codes.Domain.Codes.DomainEvents;

public sealed class CodeValidatedDomainEvent(Guid codeId) : DomainEvent
{
    public Guid CodeId { get; init; } = codeId;
}