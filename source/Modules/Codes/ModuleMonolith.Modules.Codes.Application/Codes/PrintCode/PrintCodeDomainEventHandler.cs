using ModuleMonolith.Common.Application.Messaging;
using ModuleMonolith.Modules.Codes.Domain.Codes.DomainEvents;

namespace ModuleMonolith.Modules.Codes.Application.Codes.PrintCode;

internal sealed class PrintCodeDomainEventHandler : IDomainEventHandler<PrintCodeDomainEvent>
{
    public Task Handle(PrintCodeDomainEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
