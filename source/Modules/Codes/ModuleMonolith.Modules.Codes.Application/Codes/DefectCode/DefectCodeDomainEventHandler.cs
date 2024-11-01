using ModuleMonolith.Common.Application.Messaging;
using ModuleMonolith.Modules.Codes.Domain.Codes.DomainEvents;

namespace ModuleMonolith.Modules.Codes.Application.Codes.DefectCode;

internal sealed class DefectCodeDomainEventHandler : IDomainEventHandler<DefectCodeDomainEvent>
{
    public Task Handle(DefectCodeDomainEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
